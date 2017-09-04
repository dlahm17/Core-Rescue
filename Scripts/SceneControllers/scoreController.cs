using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreController : MonoBehaviour {
   
    private float currentScore;

    private Text scoreText;


	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();

        //Comment This out ASAP and put it under the new game scripts
        PlayerPrefs.SetFloat("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
        currentScore = PlayerPrefs.GetFloat("Score");
        scoreText.text = currentScore.ToString("f0");
        print(currentScore);
	}
 
}
