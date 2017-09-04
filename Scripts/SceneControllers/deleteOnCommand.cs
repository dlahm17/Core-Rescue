using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteOnCommand : MonoBehaviour {

    public GameObject stuffToDelete;
	// Use this for initialization
 public void delete()
    {
        Destroy(stuffToDelete);
    }
}
