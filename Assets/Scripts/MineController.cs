using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour {
    
    /// <summary>
    /// Радиус взрыва
    /// </summary>
    [SerializeField] private float _radius;
    /// <summary>
    /// Сила удраной волны
    /// </summary>
    [SerializeField] private float _power;
    /// <summary>
    /// Слой взаимодействия
    /// </summary>
    [SerializeField] private LayerMask _layerMask;

    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _timeLife;

    
    private float _timeUse;
    /// <summary>
    /// Метод взрыва
    /// </summary>

    /// <summary>
    /// Массив звуков
    /// </summary>
    [SerializeField]
    private AudioClip[] _clips;
    [SerializeField]
    GameObject _exposive;
    /// <summary>
    /// Ссылка на источник звука
    /// </summary>
    private AudioSource _audiosource;
    private void Start()
    {
        _audiosource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        _timeUse = 0;
        _audiosource.clip = _clips[0];
        
    }
    void Boom()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);

        foreach (Collider2D hit in colliders)
        {
            if (hit.attachedRigidbody != null)
            {
                Vector3 direction = hit.transform.position - transform.position;
                direction.z = 0;
                hit.attachedRigidbody.AddForce(direction.normalized * _power);
                
            }
        }

        Instantiate(_exposive, transform.position, transform.rotation);    
        _audiosource.Play();
        Destroy(gameObject);
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* if (collision.tag == "Player") 
            
            {
            if (_timeUse > 1.5f)
                Boom();
                collision.gameObject.GetComponent<HeroController>().Hurt(_damage);
            }*/
        if (collision.tag == "Enemy")
             
             {
                Boom();
                collision.gameObject.GetComponent<EnemyAI>().Hurt(_damage);
             }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {/*
        if (collision.tag == "Player")
            
            {
            if (_timeUse > 1.5f)
                Boom();
                collision.gameObject.GetComponent<HeroController>().Hurt(_damage);
            }*/
        if (collision.tag == "Enemy")
            
            {
                Boom();
                collision.gameObject.GetComponent<EnemyAI>().Hurt(_damage);
            }
    }
    private void Update()
    {
        _timeUse += Time.deltaTime;
        if (_timeUse >= _timeLife)
            Boom();
    }
}
