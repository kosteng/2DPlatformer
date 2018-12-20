using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryTrigger : MonoBehaviour {
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private Text _messageField;
    private bool _story;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !_story)
        {
            _story = true;
            _panel.SetActive(true);
            _messageField.text = "Ты нашел выход, приходи позже когда разработчик сделает следующий сон, а пока можешь выйти из игры нажав клавишу Escape";
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            _panel.SetActive(false);
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && _panel.activeSelf && _story) || (Input.GetMouseButtonDown(0) && _panel.activeSelf && _story))
            Application.Quit();
    }
}
