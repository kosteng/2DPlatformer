using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Контроллер игрока
/// </summary>
public class HeroController : MonoBehaviour {
    /// <summary>
    /// Скорость движения персонажа
    /// </summary>
    [SerializeField]
    private float _moveSpeed;
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

    }

    
    void Update()
    {
     
          
        float dir = Input.GetAxis("Horizontal");
        if ( dir > 0)
        {

            transform.Translate(Time.deltaTime * dir * _moveSpeed, 0, 0);
            sr.flipX = false;
           

        }
        else if (dir < 0)
        {
            transform.Translate(Time.deltaTime * dir * _moveSpeed, 0, 0);
            sr.flipX = true;
        }

      
        // выстрел пули и проверка могу ли я совершить выстрел
        if ((Input.GetKeyDown(KeyCode.LeftControl) && _isShoot))
        {
            Shoot();
            Invoke("IsShoot", _shootDelay);
        }
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
    /// Метод разрешающий стрельбу
    /// </summary>
    private void IsShoot()
    {
        transform.rotation (Quaternion.);
        _isShoot = true;
    }

    /// <summary>
    /// Метод прыжка
    /// </summary>
    private void Jump()
    {
        if (_isJumped && !_isDoubleJumped)
        {
            _isDoubleJumped = true;
            rb.AddForce(Vector2.up * _jumpForce);
        }
        else
        {
            _isJumped = true;
            rb.AddForce(Vector2.up * _jumpForce);
        }
            
    }
}
