using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
   
    /// <summary>
    /// Скорость полета пули
    /// </summary>
    [SerializeField]
    private float _speedBullet;
   
    /// <summary>
    /// Время жизни пули
    /// </summary>
    [SerializeField]
    private float _lifeTime;
   
    /// <summary>
    /// Ссылка на SpriteRenderer пули
    /// </summary>
    private SpriteRenderer sr;
 
    /// <summary>
    /// Урон который наносит пуля
    /// </summary>
    [SerializeField]
    private int _bulletDamage;
      
    /// <summary>
    /// Массив звуков
    /// </summary>
    [SerializeField]
    private AudioClip[] _clips;
    
    /// <summary>
    /// Ссылка на источник звука
    /// </summary>
    private AudioSource _audiosource;

    /// <summary>
    /// Ссылка на компонент RidigBody
    /// </summary>
    private Rigidbody2D rb;
    void Start ()
    { 
        // Кешируем компонент SpriteRenderer пули
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //Проверка параметра жизни пули, если параметр не равен нулю запускаем уничтожением по значению параметра
        if (_lifeTime != 0)
            Destroy(gameObject, _lifeTime);
        // получаю доступ к источнику звуков и сами звуки
        _audiosource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        // запускаем пулю в направлении относительно поворота игрока
        if (!sr.flipX)
        
              transform.Translate(Time.deltaTime * _speedBullet, 0, 0);
           // rb.AddForce(Vector2.right * _speedBullet, ForceMode2D.Impulse);
        if (sr.flipX)
            transform.Translate(-Time.deltaTime * _speedBullet, 0, 0);
      //  rb.AddForce(Vector2.left * _speedBullet, ForceMode2D.Impulse);
    }
  
     void OnCollisionEnter2D(Collision2D collision)
    {
        // если враг то убиваю пулю, отнимаю здоровье врага и проигрываю звук
        if (collision.gameObject.tag == "Enemy")
        {
            
           if (collision.gameObject.GetComponent<EnemyAI>()) collision.gameObject.GetComponent<EnemyAI>().Hurt(_bulletDamage);
           if (collision.gameObject.GetComponent<BallistaController>()) collision.gameObject.GetComponent<BallistaController>().Hurt(_bulletDamage);
            _audiosource.clip = _clips[1];
            _audiosource.Play();    
        }
        Destroy(gameObject);
    }
}
