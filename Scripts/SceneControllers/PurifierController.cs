using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurifierController : MonoBehaviour {
    private float currentPurifiers;

    private Text myText;


	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        PlayerPrefs.SetFloat("Purifier", 0);
	}
	
	// Update is called once per frame
	void Update () {
        currentPurifiers = PlayerPrefs.GetFloat("Purifier");
        myText.text = currentPurifiers.ToString("f0");
        print(currentPurifiers);
	}
}
