using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {
    private GameObject player;
    private int lives;
    private float currentScore = 0;
    public Transform playerPos;
    public GameObject me;


    private float gunshot = 1;
    private float lasershot = 0;
    private float rocketshot = 0;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        lives = PlayerPrefs.GetInt("Lives");

        if (player.activeInHierarchy == false && lives >= 0)
        { 
            lives = lives - 1;
            PlayerPrefs.SetInt("Lives", lives);
            
            PlayerPrefs.SetFloat("Score", currentScore);
            StartCoroutine("respawnMyPlayer");
        }
	}

    IEnumerator respawnMyPlayer()
    {
        yield return new WaitForSeconds(1);
        Instantiate(me, playerPos.position,Quaternion.Euler(0,0,0));
       
    }
}
