using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_timescale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            Debug.Log("time = 1");

        }
        if (Time.timeScale == 0)
        {
            Debug.Log("time doesn't equal 1");
        }
	}
}
