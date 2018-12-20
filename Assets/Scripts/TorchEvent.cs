using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchEvent : MonoBehaviour {

    
    private GameObject _way;
    private bool _story;
    private bool _storyTwo;
    [SerializeField]
    Text _massegeField;
    [SerializeField]
    private GameObject _panel;
    
	void Start ()
    {
        _way = GameObject.FindGameObjectWithTag("pazzle");	
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Torch" && !_storyTwo)
        {
            _panel.SetActive(true);
            _storyTwo = true;
            _massegeField.text = "Ахх... как хорошо, мы хоть и камни, но помочь сумеем. Там где ты попал в тупик, теперь есть путь. Пока. Escape для продолжения...";
            collision.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            _way.SetActive(false);
        }
        if (collision.tag == "Player" && !_story)
        {
            _panel.SetActive(true);
            _story = true;
            _massegeField.text = "Мы древние камни, холодно нам! Хочется тепла и света... Escape для продолжения...";
        }
    }
   
    private void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Escape) && _panel.activeSelf && _story) || (Input.GetMouseButtonDown(0) && _panel.activeSelf && _story)) 
            _panel.SetActive(false);
        if ((Input.GetKeyDown(KeyCode.Escape) && _panel.activeSelf && _storyTwo) || (Input.GetMouseButtonDown(0) && _panel.activeSelf && _storyTwo))
            _panel.SetActive(false);
    }

}
