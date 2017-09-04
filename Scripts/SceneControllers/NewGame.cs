using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
    public string LevelToLoad;
    private float currentScore = 0;
    private int newLives = 3;
	// Use this for initialization

   public  void newGame()
    {
        SceneManager.LoadScene(LevelToLoad);
        PlayerPrefs.SetFloat("Score", currentScore);
        PlayerPrefs.SetInt("Lives", newLives);

    }
}
