using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm_Virus : MonoBehaviour
{
    public Collider2D mycollider;

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
        health = 10;
        
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
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward/2);


        if (health <= 0 && mydeath == false)
        {

            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
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
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_Laser"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_Laser"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Sm_Rocket"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_Rocket"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_Rocket"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Sm_bullet"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Md_bullet"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine("flashRedOnHit");
        }
        if (other.gameObject.tag.Equals("Lg_bullet"))
        {
            Destroy(gameObject);
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
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

   
}
