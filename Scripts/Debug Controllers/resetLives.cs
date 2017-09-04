using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLives : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Lives", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
