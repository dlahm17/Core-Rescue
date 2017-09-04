using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech_Basic : MonoBehaviour {
    public Transform gunPos1;
    public Transform gunPos2;
    public Transform gunPos3;
    public Transform gunPos4;
    public Transform gunPos5;
    public Transform gunPos6;

    public GameObject projectile;
    public float speed;
    public float angle1;
    public float angle2;
    public float angle3;
    public float angle4;
    public float angle5;
    public float angle6;

    public float timeToShoot;
    public float reloadTime;

    private float currentScore;


    public float health;
    private Renderer myRender;

    public Color32 hurtColor;
    public Color32 normalColor;

    public Transform self_pos;
    public GameObject self;
    public GameObject explosion;
    public float HurtTime;

    private bool mydeath;


	// Use this for initialization
	void Start () {
        mydeath = false;
        myRender = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        currentScore = PlayerPrefs.GetFloat("Score");
        transform.Translate(new Vector2(0, -1 * speed));



        if (Time.time >= timeToShoot)
        {
            Instantiate(projectile, gunPos1.position, Quaternion.Euler(0, 0, angle1));
            Instantiate(projectile, gunPos2.position, Quaternion.Euler(0, 0, angle2));
            Instantiate(projectile, gunPos3.position, Quaternion.Euler(0, 0, angle3));
            Instantiate(projectile, gunPos4.position, Quaternion.Euler(0, 0, angle4));
            Instantiate(projectile, gunPos5.position, Quaternion.Euler(0, 0, angle5));
            Instantiate(projectile, gunPos6.position, Quaternion.Euler(0, 0, angle6));
            timeToShoot = Time.time + reloadTime;

        }
        if (health <= 0 && mydeath == false)
        {
            mydeath = true;
            currentScore = currentScore + 500;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(self);
        }
	}

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag.Equals("purifierWave"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("EnemyStopper"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Player"))
            {
                Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
                Destroy(self);
            }
        if (other.gameObject.tag.Equals("Sm_laser"))
        {
            health = health - 20;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_Laser"))
        {
            health = health - 150;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_Laser"))
        {
            health = health - 50;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Sm_Rocket"))
        {
            health = health - 20;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_Rocket"))
        {
            health = health - 30;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_Rocket"))
        {
            health = health - 45;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Sm_bullet"))
        {
            health = health - 5;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_bullet"))
        {
            health = health - 10;
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_bullet"))
        {
            health = health - 15;
            StartCoroutine("flashRedOnHit");
        }
    }

  

 
    IEnumerator flashRedOnHit()
{
    myRender.material.color = hurtColor;
    yield return new WaitForSeconds(HurtTime);
    myRender.material.color = normalColor;

}
}
