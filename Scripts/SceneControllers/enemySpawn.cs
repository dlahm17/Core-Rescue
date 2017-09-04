using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {
    public GameObject enemyToSpawn;
    public Transform spotToSpawn;
   // public float timeTilSpawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (Time.time >= timeTilSpawn)
       // {
       //     Instantiate(enemyToSpawn, spotToSpawn.position, Quaternion.Euler(0, 0, 0));
       //     Destroy(gameObject);
      //  }
        
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("projectileStopper"))
        {
            Instantiate(enemyToSpawn, spotToSpawn.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }

}
