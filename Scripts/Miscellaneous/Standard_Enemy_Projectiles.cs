﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standard_Enemy_Projectiles : MonoBehaviour {
    public float speed;
    public GameObject explosion;
    public Transform self;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector2(0, -1 * speed), Space.Self);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Instantiate(explosion, self.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);

        }
        if (other.gameObject.tag.Equals("enemyStopper"))
        {
            Destroy(gameObject);
        }
    }
}
