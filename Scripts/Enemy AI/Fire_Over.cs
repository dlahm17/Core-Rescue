using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Over : MonoBehaviour {
    public BoxCollider2D myCollider;
    public BoxCollider2D otherCollider;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(otherCollider.isActiveAndEnabled == false)
        {
            Destroy(myCollider);
            Destroy(gameObject);
        }
	}
}
