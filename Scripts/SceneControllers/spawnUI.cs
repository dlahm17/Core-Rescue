using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnUI : MonoBehaviour {

    public GameObject spawnStuff;
    public Transform spotToSpawn;
	// Use this for initialization

  public  void spawn()
    {
        Instantiate(spawnStuff, spotToSpawn.position, Quaternion.Euler(0, 0, 0));
    }
}
