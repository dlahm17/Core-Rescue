using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Control : MonoBehaviour {
    private int currentLives;
    private float currentScore;
    // Use this for initialization
    private void Update()
    {
        currentScore = PlayerPrefs.GetFloat("Score");
        currentLives = PlayerPrefs.GetInt("Lives");
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("1up"))
        {
            currentLives = currentLives + 1;
            PlayerPrefs.SetInt("Lives", currentLives);
            currentScore = currentScore + 10000;
            PlayerPrefs.SetFloat("Score", currentScore);
        }
    }
}
