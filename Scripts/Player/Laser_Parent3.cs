using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Parent3 : MonoBehaviour {
    public GameObject self;
    private GameObject newParent;
    // Use this for initialization
    void Start()
    {
        newParent = GameObject.FindGameObjectWithTag("Laser_Spawn3");

    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position = newParent.transform.position;
    }
}
