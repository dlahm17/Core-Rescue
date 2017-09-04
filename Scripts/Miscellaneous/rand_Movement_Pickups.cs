using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand_Movement_Pickups : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
    private void FixedUpdate()
    {
        transform.Translate(new Vector2(0, -1 * speed));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
