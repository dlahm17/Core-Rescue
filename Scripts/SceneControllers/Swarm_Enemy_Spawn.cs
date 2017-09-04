using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm_Enemy_Spawn : MonoBehaviour {

    public GameObject enemyToSpawn;
    public Transform spotToSpawn;
    public Transform spotToSpawn2;
    public Transform spotToSpawn3;
    public Transform spotToSpawn4;
    public Transform spotToSpawn5;
    public Transform spotToSpawn6;
    public Transform spotToSpawn7;
    public Transform spotToSpawn8;
    // public float timeTilSpawn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
            Instantiate(enemyToSpawn, spotToSpawn.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn2.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn3.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn4.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn5.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn6.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn7.position, Quaternion.Euler(0, 180, 0));
            Instantiate(enemyToSpawn, spotToSpawn8.position, Quaternion.Euler(0, 180, 0));
            Destroy(gameObject);
        }
    }

}