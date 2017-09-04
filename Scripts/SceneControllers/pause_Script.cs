using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause_Script : MonoBehaviour {
    private bool ispaused;
    public GameObject canvasToSpawn;
    public Transform me;
    private GameObject myCanvas;


    private GameObject player;
    private bool pausable;
	// Use this for initialization
	void Start () {
        ispaused = false;
        pausable = true;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.activeInHierarchy == true)
        {
            pausable = true;
        }
        else
        {
            pausable = false;
        }

		if (Input.GetButtonDown("Escape"))
        {
            Debug.Log("pausing");
            pause();
        }

        myCanvas = GameObject.FindGameObjectWithTag("pauseCanvas");
	}

    void pause()
    {


        if (ispaused == true && pausable == true)
        {
            
            Destroy(myCanvas);
            Time.timeScale = 1;
            ispaused = false;
        }
        else
        {
            Time.timeScale = 0;
            ispaused = true;
            Instantiate(canvasToSpawn, me.position, Quaternion.Euler(0, 0, 0));

        }
    }
    
}
