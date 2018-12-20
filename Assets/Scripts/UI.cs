using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour {
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _panel;
    private int _messageCount;
	
	void Start () {
        _text.text = "Привет, это сон и тебе нужно пройти уровень чтобы проснутся. Нажмите на клавишу Escape для продолжения...";
        _messageCount = 0;
	}

    void Update () {
        if ((Input.GetKeyDown(KeyCode.Escape) && _messageCount == 0) || (Input.GetMouseButtonDown(0) && _messageCount == 0))
        {
            _text.text = "Нажимите стрелки чтобы перемещаться, пробел для прыжка(можно прыгать дважды), левый контрол для стрельбы, F для броска мины Escape для продолжения...";
            _messageCount++;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && _messageCount == 1) || (Input.GetMouseButtonDown(0) && _messageCount == 1))
            {
            _text.text = "Тебе нужно идти, но будь осторожен, кругом враги Escape для продолжения...";
            _messageCount++;

        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && _messageCount == 2) || (Input.GetMouseButtonDown(0) && _messageCount == 2))
            {
            _messageCount++;
            _panel.SetActive(false);
        }
    }
}
