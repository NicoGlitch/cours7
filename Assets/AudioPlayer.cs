using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {
    private AudioSource audiosource;
	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
	}
	
    public void playMusic(AudioMusic audioMusic)
    {
        audiosource.clip = audioMusic.soundToPlay;
        audiosource.Play();
    }
}
