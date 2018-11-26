using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    /// <summary>
    /// Очки жизни врага
    /// </summary>
    [SerializeField]
    private float _health;

    
    /// <summary>
    /// Цель к которой следует враг
    /// </summary>
    private Transform _target;
    
    /// <summary>
    /// Скорость движения врага
    /// </summary>
    [SerializeField]
    private float _speedMove;
   
    /// <summary>
    /// Параметр отслеживает в какую сторону движется враг для повората его спрайт в нужную сторону
    /// </summary>
    private float _xMove;
    
    /// <summary>
    /// Ссылка на SpriteRenderer врага
    /// </summary>
    private SpriteRenderer sr;
    
    void Start () {
        // кешируем компонент SpriteRenderer врага
        sr = GetComponent<SpriteRenderer>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        
        
	}
    
    /// <summary>
    /// Метод вычитания здоровья врага
    /// </summary>
    /// <param name="damage">Параметр урона по врагу</param>
    public void Hurt(float damage)
    {
        _health -= damage;
    }
   
  
   
    /// <summary>
    /// Метод движения врага
    /// </summary>
    void Move()
    {
        // запоминаем в значение врага по оси Х
        _xMove = transform.position.x;
        // движение в сторону цели
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speedMove * Time.deltaTime);
        // поворот спрайта врага относительно его положения
        if (transform.position.x > _xMove)
            sr.flipX = true;
        else sr.flipX = false;
    }

    
    void Update ()
    {
        if (_target != null) Move();
        // проверка здоровья врага на смерть
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
	}
}
