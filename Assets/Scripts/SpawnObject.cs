using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    /// <summary>
    /// Объект который нужно создать
    /// </summary>
    [SerializeField]
    private GameObject _spawnObject;
   
    /// <summary>
    /// Отвечает за повтор создания объекта
    /// </summary>
    [SerializeField]
    private bool _loop;
   
    /// <summary>
    /// Время в секундах через которое создатся объект
    /// </summary>
    [SerializeField]
    private float _spawnTimeObject;
   
    /// <summary>
    /// Задержка в секундах между созданием объектов
    /// </summary>
    [SerializeField]
    private float _spawnDelayTimeObject;
    void Start()
    {
        // Создаем объект и спрашиваем нужен ли этот объект с заданной переодичностью
        if (_loop)
            InvokeRepeating("Spawn", _spawnTimeObject, _spawnDelayTimeObject);
        else Invoke("Spawn", _spawnTimeObject);
    }
    /// <summary>
    /// Метод создания объекта
    /// </summary>
    private void Spawn ()
    {
        // если есть ссылка на объект то создаем его в позиции объекта спауннера 
        if (_spawnObject != null)
            Instantiate(_spawnObject, transform.position, Quaternion.identity);
    }
}