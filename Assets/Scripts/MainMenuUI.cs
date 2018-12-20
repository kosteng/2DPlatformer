﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour {
    [SerializeField]
    private Slider _slider;
  

   


    
    // Update is called once per frame
    void Update () {
        AudioListener.volume = _slider.value;
      
	}
    public void Exit ()
    {
        Application.Quit();

    }
    public void LoadLevel()
    {
        Application.LoadLevel(1);
    }
}