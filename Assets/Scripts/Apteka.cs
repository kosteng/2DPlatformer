using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apteka : MonoBehaviour {
    [SerializeField]
    private int _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<HeroController>().Health(_health);
        }
        Destroy(gameObject);
    }
}
