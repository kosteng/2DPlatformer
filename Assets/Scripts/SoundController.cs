using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    
    public AudioClip[] _allAudioClip;
    public AudioSource _audioSource;
    void Start () {
        _audioSource = GetComponent<AudioSource>();
    }
	
}
