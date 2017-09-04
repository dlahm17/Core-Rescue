using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrier_Virus : MonoBehaviour {
    public Color32 normalColor;
    public Color32 hurtColor;
    public float HurtTime;

    public float health;

    private float currentScore;
    private Animator myAnim;
    private Renderer myRender;

    public float spawnTime;
    public float SpawnReload;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public GameObject enemyToSpawn;


    public float speed;
    public float downSpeed;
    public GameObject explosion;
    public Transform self_pos;

    private bool myDeath;
    private BoxCollider2D myCollider;
    public float deathTime;

    private bool ReadyToSpawn;

    public float moveTime;
    public float TimeToMove;
	// Use this for initialization
	void Start () {

        moveTime = Time.time + TimeToMove;
        myRender = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
	}
    private void Update()
    {
        currentScore = PlayerPrefs.GetFloat("Score");
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (Time.time >= spawnTime && myDeath ==false && ReadyToSpawn == true) {
            spawn();
        }
        if (health <= 0 && myDeath == false)
        {
            death();
        }

        if (Time.time <= moveTime)
        {
            transform.Translate(new Vector2(0, -downSpeed));
        }
        if (Time.time >= moveTime)
        {
            moveWithCamera();
        }
	}

    void moveWithCamera()
    {
        transform.Translate(new Vector2(0, 1 * speed));
        ReadyToSpawn = true;
    }
    void spawn()
    {
        Instantiate(enemyToSpawn, spawnPoint1.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemyToSpawn, spawnPoint2.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemyToSpawn, spawnPoint3.position, Quaternion.Euler(0, 0, 0));
        Instantiate(enemyToSpawn, spawnPoint4.position, Quaternion.Euler(0, 0, 0));
        spawnTime = Time.time + SpawnReload;
    }
    void death()
    {

        StartCoroutine("waitForDeath");
        currentScore = currentScore + 1000;
        PlayerPrefs.SetFloat("Score", currentScore);
        myDeath = true;
        Destroy(myCollider);
        myAnim.SetBool("Death", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("purifierWave"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            health = health - 500;
        }
        if (other.gameObject.tag.Equals("EnemyStopper"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Player"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
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
}

