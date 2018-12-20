using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Text _messageField;
    private bool _story;
    
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_story)
        {
            _story = true;
            _panel.SetActive(true);
            _messageField.text = "Хм.. Похоже проход закрыт. Но если вспомнить начало, и поднять взор высоко вверх. Возможно это поможет... Escape для продолжения...";
        }

    }
  
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)  && _story) || (Input.GetMouseButtonDown(0) && _story))
            _panel.SetActive(false);
    }
}
