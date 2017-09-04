using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live_Display : MonoBehaviour {

    private int lives;
    private Text lifeText;
	// Use this for initialization
	void Start () {
        lifeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        lives = PlayerPrefs.GetInt("Lives");
        lifeText.text = lives.ToString("f0");
        print(lives);
		
	}
}
