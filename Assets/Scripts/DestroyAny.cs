using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAny : MonoBehaviour {
    [SerializeField]
    private float _timeDie;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, _timeDie);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
