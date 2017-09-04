using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue_game : MonoBehaviour {
    private int playerLives;
    private int currentScore;
    
	// Use this for initialization
	void Start () {
       
        playerLives = PlayerPrefs.GetInt("Lives");
	}
	


    public void continueGame()
    {

        Scene loadedLevel = SceneManager.GetActiveScene();
        playerLives = playerLives - 1;
            PlayerPrefs.SetInt("Lives", playerLives);
        PlayerPrefs.SetFloat("Score", 0);
        PlayerPrefs.SetInt("gunShooter", 1);
        PlayerPrefs.SetInt("rocketShooter", 0);
        PlayerPrefs.SetInt("laserShooter", 0);
        PlayerPrefs.SetInt("Purifier", 0);
        SceneManager.LoadScene(loadedLevel.buildIndex);



    }
}
