using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string levelToLoad;

    public void loadscene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}