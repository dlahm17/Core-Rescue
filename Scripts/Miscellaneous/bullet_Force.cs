using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_Force : MonoBehaviour {
    public float speed;
    public GameObject myExplosion;
    public Transform me;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector2(0, 1 * speed), Space.Self);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(myExplosion, me.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("projectileStopper"))
        {
            Destroy(gameObject);
        }
    }
}
