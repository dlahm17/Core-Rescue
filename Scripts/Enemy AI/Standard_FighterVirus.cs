using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standard_FighterVirus : MonoBehaviour {

    private BoxCollider2D mycollider;

    private float currentScore;
    private GameObject player;
    public GameObject self;
    private Transform Player;

    public float speed;


    private float health;


    public Color32 normalColor;
    public Color32 hurtColor;
    public GameObject explosion;
    private Renderer myRender;
    public float HurtTime;
    public Transform self_pos;

    private bool mydeath;

    // Use this for initialization

    private void Start()
    {
        myRender = GetComponent<Renderer>();
        health = 50;
        mycollider = GetComponent<BoxCollider2D>();
        mydeath = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {

        Player = player.transform;
        transform.Translate(new Vector3(0, 1 * speed, 0), Space.Self);

    }

    // Update is called once per frame
    void Update()
    {
        currentScore = PlayerPrefs.GetFloat("Score");
        Vector3 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward / 2);


        if (health <= 0 && mydeath == false)
        {
            currentScore = PlayerPrefs.GetFloat("Score");
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Destroy(mycollider);
            selfdeath();
            mydeath = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("purifierWave"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
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

        if (other.gameObject.tag.Equals("EnemyStopper"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator flashRedOnHit()
    {
        myRender.material.color = hurtColor;
        yield return new WaitForSeconds(HurtTime);
        myRender.material.color = normalColor;

    }

    void selfdeath()
    {
        currentScore = currentScore + 100;
        PlayerPrefs.SetFloat("Score", currentScore);
        Destroy(gameObject);
        Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
    }
}

