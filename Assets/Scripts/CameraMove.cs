using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
   /// <summary>
   /// Ссылка на игрока
   /// </summary>
   private GameObject _target;
	void Start () {
        _target = GameObject.FindGameObjectWithTag("Player");

	}
	
	// камера следует за игроком
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 1);
        
	}
}
