using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMe : MonoBehaviour {
    public float aliveTime;
	// Use this for initialization
	void Start () {
        aliveTime = Time.time + aliveTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.time >= aliveTime)
        {
            Destroy(gameObject);
        }
	}
}
