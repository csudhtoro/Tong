﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballHandler : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float multiplier = .0f;
    public AudioSource hitSource;
    GameObject[] theRacket;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        hitSource = GetComponent<AudioSource>();
        theRacket = GameObject.FindGameObjectsWithTag("Racket");
        Invoke("GoBall", 2);
        
    }

    // Update is called once per frame

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(40, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-40, -15));
        }
    }

    
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        foreach (GameObject racket in theRacket) {
            racket.SendMessage("ResetRacket", 0.5f, SendMessageOptions.RequireReceiver);
        }
        ResetBall();
        Invoke("GoBall", 1);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Racket")) hitSource.Play();

        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
            multiplier++;
        }
    }
}
