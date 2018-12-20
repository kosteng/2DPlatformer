using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBalliasta : MonoBehaviour
{

    /// <summary>
    /// Скорость полета стрелы
    /// </summary>
    [SerializeField]
    private float _speedArrow;

    /// <summary>
    /// Время жизни стрелы
    /// </summary>
    [SerializeField]
    private float _lifeTime;

    /// <summary>
    /// Ссылка на SpriteRenderer стрелы
    /// </summary>
    private SpriteRenderer sr;

    /// <summary>
    /// Урон который наносит пуля
    /// </summary>
    [SerializeField]
    private int _arrowDamage;

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
    Vector2 _dir = new Vector2(1, 0);
    public bool isRight;
    void Start()
    {
      //  transform.Rotate(0, 180, 0);
        rb = GetComponent<Rigidbody2D>();
        //Проверка параметра жизни пули, если параметр не равен нулю запускаем уничтожением по значению параметра
        if (_lifeTime != 0)
            Destroy(gameObject, _lifeTime);
        // получаю доступ к источнику звуков и сами звуки
        _audiosource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * _speedArrow, 0, 0);
        rb.AddForce(Vector2.zero * _speedArrow, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // если враг то убиваю пулю, отнимаю здоровье врага и проигрываю звук
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<HeroController>().Hurt(_arrowDamage);
            _audiosource.clip = _clips[0];
            _audiosource.Play();
        }
        Destroy(gameObject);
    }
}
