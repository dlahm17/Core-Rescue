using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thousandPoints : MonoBehaviour {
    private float currentScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("1kPoint"))
        {
            currentScore = PlayerPrefs.GetFloat("Score");
            currentScore = currentScore + 1000;
            PlayerPrefs.SetFloat("Score", currentScore);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("10kPoint"))
        {
            currentScore = PlayerPrefs.GetFloat("Score");
            currentScore = currentScore + 10000;
            PlayerPrefs.SetFloat("Score", currentScore);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("20kPoint"))
        {
            currentScore = PlayerPrefs.GetFloat("Score");
            currentScore = currentScore + 20000;
            PlayerPrefs.SetFloat("Score", currentScore);
            Destroy(other.gameObject);
        }
    }
}
