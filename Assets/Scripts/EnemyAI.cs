using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// Жизнь врага
    /// </summary>
    [SerializeField]
    private int _health;

    /// <summary>
    /// Сила атаки врага
    /// </summary>
    [SerializeField]
    private int _damageAttack;

    /// <summary>
    /// Минимальное расстояние для дистанционной атаки
    /// </summary>
    [SerializeField]
    private float _minDistanceAttack;

    /// <summary>
    /// Минимальное расстояние для атаки ближнего боя
    /// </summary>
    [SerializeField]
    private float _minMeleeAttack;

    /// <summary>
    /// Скорость перемещения врага
    /// </summary>
    [SerializeField]
    private float _speed;

    /// <summary>
    /// Перезарядка врага
    /// </summary>
    [SerializeField]
    private float _reloadTime;

    /// <summary>
    /// Цель для атаки врага
    /// </summary>
    [SerializeField]
    private GameObject _target;

    /// <summary>
    /// Снаряды которыми бьет враг
    /// </summary>
    [SerializeField]
    private GameObject _bullet;

    /// <summary>
    /// Состояние злости и готовности атаковать
    /// </summary>
    [SerializeField]
    private bool _angry;

    /// <summary>
    /// Направление в которое смотрит враг
    /// </summary>
    [SerializeField]
    private bool _isRight;

    /// <summary>
    /// Готовность к следующей атаке
    /// </summary>
    [SerializeField]
    private bool _coolDown;

    /// <summary>
    /// Содержит префаб поджопника
    /// </summary>
    [SerializeField]
    private GameObject _orPos;

    /// <summary>
    /// Сам поджопник
    /// </summary>
    private GameObject _backPos;

    /// <summary>
    /// Дистанция видимости целей врагом
    /// </summary>
    [SerializeField]
    private float _seePoint;

    /// <summary>
    ///  Место стрельбы
    /// </summary>
    [SerializeField]
    private GameObject _shotPlace;
    /// <summary>
    /// Дистанция до которой нужно дойти чтобы атаковать в ближнем бою
    /// </summary>
    [SerializeField]
    private float _meleePosition;
    /// <summary>
    /// Флаг разрешающий стрельбу на месте
    /// </summary>
    private bool _stayForAttack;

    private void Start()
    {
        // ищем игрока
        _target = GameObject.FindGameObjectWithTag("Player");
        // создаем поджопник
        _backPos = Instantiate(_orPos, transform.position, Quaternion.identity) as GameObject;
    }

    /// <summary>
    /// Метол ходьбы
    /// </summary>
    /// <param name="Target">Пункт назначения</param>
    private void MoveTo(GameObject Target)
    {
        float x = Target.transform.position.x - transform.position.x;
        if (x < 0 && _isRight)
            Flip();
        else if (x > 0 && !_isRight)
            Flip();
        // если злые и минимальная дистанция для атаки подходит для удара и расстояние до удара больше то идем к цели
        
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    
    }
    
 
    private void FixedUpdate()
    {
        float dis = Vector2.Distance(transform.position, _target.transform.position);

        //// если видим игрока то злимся, если не видим то не злимся
        if (dis <= _seePoint)
            _angry = true;
        else _angry = false;
        if (_angry)
        {
            // если злые, идем к игроку и если позволяет дистанция стрелять, стреляем  
            if (!_stayForAttack)
            {
                MoveTo(_target);
            }

            if (dis <= _minDistanceAttack && dis > _minMeleeAttack)
            // передаем в метод атаки поведение, если истина стреляем, если ложь ближний бой
            {
                EngageDis();
                _stayForAttack = true;
            }
            else if (dis <= _minMeleeAttack && dis > _meleePosition)
            {
                _stayForAttack = false;
                MoveTo(_target);
            } else if (dis <= _meleePosition)
                EngageMelee();  
        }
        else MoveTo(_backPos);
    }
    /// <summary>
    /// Метод атаки по врагу
    /// </summary>
    /// <param name="Damage">Сила атаки</param>
    public void Hurt(int Damage)
    {
        _health -= Damage;
        if (_health < 1)
            Die();
    }
    /// <summary>
    /// Смерть врага
    /// </summary>
    private void Die()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// Метод атаки
    /// </summary>
    /// <param name="shoot">Проверка на тип атаки, если истина дистанционная атака, если ложь то ближний бой</param>
    private void EngageMelee()
    {
        if (!_coolDown)
        {
            _coolDown = true;
            Invoke("Reload", _reloadTime);
            _target.GetComponent<HeroController>().Hurt(_damageAttack);
        }
    }

    private void EngageDis()
    {
        if (!_coolDown)
        {
            _coolDown = true;
            Invoke("Reload", _reloadTime);
            Instantiate(_bullet, _shotPlace.transform.position, transform.rotation);
        }
    }
    /// <summary>
    /// Перезарядка
    /// </summary>
    private void Reload()
    {
        _coolDown = false;
    }
    /// <summary>
    /// Поворот врага
    /// </summary>
    private void Flip()
    {
        _isRight = !_isRight;
        transform.Rotate(0, 180, 0);
    }
}
