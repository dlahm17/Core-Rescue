using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWithExplosion : MonoBehaviour {
    private float aliveTime;
    public float aliveTime2;
    public GameObject explosion;
    public Transform self_Pos;

    public GameObject self;
	// Use this for initialization
	void Start () {
        aliveTime = Time.time + aliveTime2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= aliveTime && self.activeInHierarchy == true)
        {

            Instantiate(explosion, self_Pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            

        }
	}
}
