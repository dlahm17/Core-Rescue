using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PreLoadScenes : MonoBehaviour {
    public string sceneToLoad;
    string preloadWords;
    string PostLoadWords;

    private Text myText;
    public float timeToLoad;
    private bool loaded;
	// Use this for initialization
	void Start () {
        loaded = false;
        preloadWords = "Loading Please Wait";
        PostLoadWords = "Press Fire to continue";
        myText = GetComponent<Text>();
        SceneManager.LoadSceneAsync(sceneToLoad);
        
        

        
    }
	
	// Update is called once per frame
	//void Update () {
		//if (loaded == false)
        //{
         //   myText.text = preloadWords;
          //  print(myText);
        //}
       // if (Time.time >= timeToLoad)
        //{
         //   loaded = true;
        //}
       // if (loaded == true)
       // {
       //     myText.text = PostLoadWords;
        //    print(myText);
       // }
       // if (loaded == true && Input.GetAxisRaw("Fire1") > 0)
        //{
        //    SceneManager.LoadScene(sceneToLoad);
        //}
	//}
    
}
