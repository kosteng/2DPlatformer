using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaController : MonoBehaviour {

    [SerializeField]
    private int _health;
    [SerializeField]
    private GameObject _shootPlace;

    [SerializeField]
    private GameObject _arrow;
    /// <summary>
    /// Массив звуков
    /// </summary>
    [SerializeField]
    private AudioClip[] _clips;

    /// <summary>
    /// Ссылка на источник звука
    /// </summary>
    private AudioSource _audiosource;
    [SerializeField]
    private float _reloadBallista;
    [SerializeField]
    private bool _isRight = true;
    private void Start()
    {
        _audiosource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        _reloadBallista += Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x && _isRight)
              Flip();
            else if (collision.transform.position.x > transform.position.x && !_isRight)
              Flip();
            Attack();
        }
    }
    void Flip()
    {
        _isRight = !_isRight;
        transform.Rotate(0, 180, 0);
    }

   

    public void Attack()
    {
        if (_shootPlace != null && _reloadBallista > 1f)
        {
            _reloadBallista = 0;
            Instantiate(_arrow, _shootPlace.transform.position, transform.rotation);
            _audiosource.clip = _clips[0];
            _audiosource.Play();
        }

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
}
