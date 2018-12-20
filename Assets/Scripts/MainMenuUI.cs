using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour {
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private GameObject TrailRender;
    private GameObject GO;

    void Start () {
        GO = Instantiate(TrailRender, transform.position, transform.rotation);
	}


    private void Move()
    {
       // if (Input.touchCount <= 0) return;
        Vector2 delta = Input.GetTouch(0).deltaPosition;
        if (Input.anyKey)
        GO.transform.position = Vector2.MoveTowards(GO.transform.position, delta, 1);
    }
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
