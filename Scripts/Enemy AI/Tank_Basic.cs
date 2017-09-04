using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Basic : MonoBehaviour
{
    private float currentScore;


    public Color32 normalColor;
    public Color32 hurtColor;
    public float HurtTime;

    private Animator myAnim;

    private Renderer myRender;
    public float speed;
    public GameObject bullet;
    public Transform bulletSpawn;

    public float bulletFire;
    public float timeToReload;
   public  float health;
    public GameObject explosion;
    public Transform self_pos;
    public GameObject self;

    public BoxCollider2D myCollider;

    private bool death;

    private bool mydeath;

    public float deathTime;
    // Use this for initialization
    void Start()
    {
        mydeath = false;
        myRender = GetComponent<Renderer>();
        myAnim = GetComponent<Animator>();
        death = false;
        bulletFire = Time.time + bulletFire;
        myAnim.SetBool("Death", false);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        currentScore = PlayerPrefs.GetFloat("Score");

        if (health <= 0 && mydeath == false)
        {
            selfdeath();
            mydeath = true;
        }
        
        transform.Translate(new Vector2(0, -1 * speed), Space.Self);

        if (Time.time >= bulletFire && death == false)
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(0, 0, 0));
            bulletFire = Time.time + timeToReload;
        }
        
    }
  
 
    void OnTriggerEnter2D(Collider2D other)
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
            Destroy(gameObject);
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
    IEnumerator waitForDeath()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
    void selfdeath()
    {
        currentScore = currentScore + 750;
        PlayerPrefs.SetFloat("Score", currentScore);
        Destroy(myCollider);
        myAnim.SetBool("Death", true);
        StartCoroutine("waitForDeath");
        death = true;
    }

}
