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
    private float _bulletDamage;
      
    /// <summary>
    /// Массив звуков
    /// </summary>
    [SerializeField]
    private AudioClip[] _clips;
    
    /// <summary>
    /// Ссылка на источник звука
    /// </summary>
    private AudioSource _audiosource;
    
    void Start () { 
        // Кешируем компонент SpriteRenderer пули
        sr = GetComponent<SpriteRenderer>();
        //Проверка параметра жизни пули, если параметр не равен нулю запускаем уничтожением по значению параметра
        if (_lifeTime != 0)
            Destroy(gameObject, _lifeTime);
        // получаю доступ к источнику звуков и сами звуки
        _audiosource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
       
      
    }


    void Update () {
        // запускаем пулю в направлении относительно поворота игрока
        if (!sr.flipX)
        transform.Translate(Time.deltaTime * _speedBullet, 0, 0);
        if (sr.flipX)
            transform.Translate(-Time.deltaTime * _speedBullet, 0, 0);
		
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        // если враг то убиваю пулю, отнимаю здоровье врага и проигрываю звук
        if (collision.gameObject.tag == "Enemy")
        {
            
            collision.gameObject.GetComponent<EnemyController>().Hurt(_bulletDamage);
            _audiosource.clip = _clips[1];
            _audiosource.Play();
            Destroy(gameObject);
        }

    }
}
