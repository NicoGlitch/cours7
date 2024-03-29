﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiCube : Ennemi {

    GameObject player;
    public float speed = 5;
    Rigidbody rbd;
    AudioSource audioSource;
    public AudioMusic audiomusic;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rbd = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        followPlayer();

    }

    private void followPlayer()
    {
        rbd.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime));
    }
    public override void Die()
    {
        audioSource.PlayOneShot(audiomusic.soundToPlay);
        Destroy(gameObject);
    }
}
