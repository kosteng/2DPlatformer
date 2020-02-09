using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Контроллер игрока
/// </summary>
public class HeroController : MonoBehaviour {
    [SerializeField]
    private Text _messageField;
    [SerializeField]
    private GameObject _panel;
    /// <summary>
    /// Отображение жизни игрока
    /// </summary>
    [SerializeField]
    private Text _textHealth;
    [SerializeField]
    private int _health;
    /// <summary>
    /// Скорость движения персонажа
    /// </summary>
    [SerializeField]
    private float _moveSpeed;
    
    /// <summary>
    /// Максимальная скорость передвижения персонажа
    /// </summary>
    [SerializeField]
    private float _moveMaxSpeed;
   
    /// <summary>
    ///  Массив звуков
    /// </summary>
    [SerializeField]
    private AudioClip[] _clips;
   
    /// <summary>
    /// Источник звука
    /// </summary>
    private AudioSource _audiosource;
    /// <summary>
    /// Ссылка на мину
    /// </summary>
    [SerializeField]
    private GameObject _mine;
    /// <summary>
    /// Ссылка на пулю
    /// </summary>
    [SerializeField]
    private GameObject _bullet;
   
    /// <summary>
    /// Ссылка на позицию дула ружья когда игрок смотрит влево
    /// </summary>
    [SerializeField]
    private GameObject _placeShotLeft;
   
    /// <summary>
    /// Сила прыжка
    /// </summary>
    [SerializeField]
    private float _jumpForce;
    
    /// <summary>
    /// Флаг на прыжок
    /// </summary>
    private bool _isJumped;

    /// <summary>
    /// Флаг на прыжок
    /// </summary>
    private bool _isDoubleJumped;
   
    /// <summary>
    /// Ссылка на позицию дула ружья когда игрок смотрит вправо
    /// </summary>
    [SerializeField]
    private GameObject _placeShotRight;
   
    /// <summary>
    /// Ссылка на компонент SpriteRenderer игрока
    /// </summary>
    private SpriteRenderer sr;
   
    /// <summary>
    /// Ссылка на компонент Rigidbody2d игрока
    /// </summary>
    private Rigidbody2D rb;
    
    /// <summary>
    /// Ссылка на слой земли
    /// </summary>
    [SerializeField]
    private LayerMask _whatIsGround;
    
    /// <summary>
    /// Проверка на возможность стрельбы
    /// </summary>
    private bool _isShoot = true;
    
    /// <summary>
    /// Временной интервал между выстрелами
    /// </summary>
    [SerializeField]
    private float _shootDelay;

    /// <summary>
    /// Направление движения персонажа
    /// </summary>
    private Vector2  _dir = Vector2.zero;

    private bool _die;
    /// <summary>
    /// Проверяю коллизию на какой слой упал игрок
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if (collision.otherCollider.IsTouchingLayers(_whatIsGround))
            _isJumped = false;
            _isDoubleJumped = false;
    }

    void Start ()
    {
        // при старте кешируем компоненты 
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _audiosource = GetComponent<AudioSource>();
   //     _textHealth.text ="Жизнь: " + _health;
    }
   public void Fire()
    {
        if ( _isShoot)
        {
            Shoot();
            Invoke("IsShoot", _shootDelay);
        }
    }

    void Update()
    {
        #if UNITY_ANDROID
        _dir.x = CrossPlatformInputManager.GetAxis("Horizontal") * _moveSpeed;
        #endif

        #if UNITY_STANDALONE_WIN 
        _dir.x = Input.GetAxis("Horizontal") * _moveSpeed;
        #endif
        #if UNITY_EDITOR
        _dir.x = Input.GetAxis("Horizontal") * _moveSpeed;
        #endif
        if ( _dir.x > 0)
        {
            rb.AddForce(Vector2.right * _dir.x, ForceMode2D.Force);
            //transform.Translate(Time.deltaTime * dir * _moveSpeed, 0, 0);
            sr.flipX = false;
        }

        else if (_dir.x < 0)
        {
            rb.AddForce(Vector2.right * _dir.x, ForceMode2D.Force);
            //transform.Translate(Time.deltaTime * dir * _moveSpeed, 0, 0);
            sr.flipX = true;   
        }

        if (Mathf.Abs(rb.velocity.x) > _moveMaxSpeed)
        {
            _dir = rb.velocity;
            _dir.x = Mathf.Clamp(rb.velocity.x, -_moveMaxSpeed, _moveMaxSpeed);
            rb.velocity = _dir;
        }
      
        // выстрел пули и проверка могу ли я совершить выстрел
        if ((Input.GetKeyDown(KeyCode.LeftControl) && _isShoot))
        {
            Shoot();
            Invoke("IsShoot", _shootDelay);
        }

        // мины
        if (Input.GetKeyDown(KeyCode.F))
            Minner();
        // прыжок
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            if (!_isJumped)
            {
                Jump();
            }
            else if (_isJumped && !_isDoubleJumped)
            {
                Jump();
            }
        }
        if (_health < 1)
            Die();
        if (Input.GetKeyDown(KeyCode.Escape) && _die)
        {
            Application.LoadLevel(0);
            Time.timeScale = 1f;
        }
    }
    public void JumpForce()
    {
        if (!_isJumped)
        {
            Jump();
        }
        else if (_isJumped && !_isDoubleJumped)
        {
            Jump();
        }
    }
    /// <summary>
    /// Метод стрельбы
    /// </summary>
    private void Shoot()
    {
        // ставлю на перезаряд
        _isShoot = false;
        // проигрываю звук, почему делаю массивом возможно пригодятся и другие звуки    
        _audiosource.clip = _clips[0];
        _audiosource.Play();
        // поворачиваю пулю относительно игрока
        _bullet.GetComponent<SpriteRenderer>().flipX = sr.flipX;
        // проверяем положения игрока и относильного него пускаем пулю 
        // возможно реализация ужастна, если с вашей стороны будет какая-либо критика, буду весьма признателен
        if (sr.flipX) Instantiate(_bullet, _placeShotLeft.transform.position, transform.rotation);
        if (!sr.flipX) Instantiate(_bullet, _placeShotRight.transform.position, transform.rotation);
    }
    /// <summary>
    /// Метод укладки мины
    /// </summary>
    public void Minner()
    {
        if (sr.flipX) Instantiate(_mine, _placeShotLeft.transform.position, transform.rotation);
        if (!sr.flipX) Instantiate(_mine, _placeShotRight.transform.position, transform.rotation);
    }
    /// <summary>
    /// Метод разрешающий стрельбу
    /// </summary>
    private void IsShoot()
    {
        
        _isShoot = true;
    }

    /// <summary>
    /// Метод прыжка
    /// </summary>
    public void Jump()
    {
        if (_isJumped && !_isDoubleJumped)
        {
            _isDoubleJumped = true;
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            _isJumped = true;
            rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
            
    }

    /// <summary>
    /// Метод вычитания здоровья врага
    /// </summary>
    /// <param name="damage">Параметр урона по врагу</param>
    public void Hurt(int damage)
    {
        _health -= damage;
        _textHealth.text = "Жизнь: " + _health;
    }

    public void Health(int health)
    {
        _health += health;
        _textHealth.text = "Жизнь: " + _health;

    }
    private void Die()
    {
        _die = true;
        _panel.SetActive(true);
        _messageField.text = "Ну что ж, не повезло, нажми Ecsape и начни сначала, а так, совет мой - нужно было аптечки покушать";
        Time.timeScale = 0.00000000001f;
    }
       
}
