using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    public float speed;
    public float fastSpeed;

    public float startTime;
    public float stopTime;
    public float endLevel;

    public GameObject levelEndCanvas;
    public Transform myCamera;

    private bool startTimeYes;
    private bool stopTimeYes;
    private bool endAll;
    private bool finished;
    private bool canDo;

    private GameObject player;
	// Use this for initialization
	void Start () {
      
        canDo = true;
        player = GameObject.FindGameObjectWithTag("Player");
        startTimeYes = true;
        stopTimeYes = true;
        endAll = true;
        finished = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (player.activeInHierarchy == true)
        {
            canDo = true;
        }
        else
        {
            canDo = false;
        }


        if (Time.timeSinceLevelLoad >= endLevel && finished == false && canDo == true)
        {
            finished = true;
            endAll = false;
            StartCoroutine("spawnlevelEndCanvas");
        }
        if (Time.timeSinceLevelLoad >= stopTime && endAll == true)
        {
            transform.Translate(new Vector2(0, fastSpeed));
            stopTimeYes = false;
        }
        if (Time.timeSinceLevelLoad >= startTime && stopTimeYes == true)
        {
            transform.Translate(new Vector2(0, speed));
            startTimeYes = false;

        }

        if (Time.timeSinceLevelLoad < startTime && startTimeYes == true)
        {
            transform.Translate(new Vector2(0, fastSpeed));
        }
    
   
     
    }
    IEnumerator spawnlevelEndCanvas()
    {
        yield return new WaitForSeconds(1);
        Instantiate(levelEndCanvas, myCamera.position, Quaternion.Euler(0, 0, 0));
    }


}
