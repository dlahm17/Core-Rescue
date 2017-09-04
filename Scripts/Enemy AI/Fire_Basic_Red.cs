using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Basic_Red : MonoBehaviour {
    public float health;

    public Color32 hurtColor;
    public Color32 normalColor;
    public float HurtTime;

    private Renderer myRender;

    private float currentScore;
    public Transform self_pos;

    public GameObject explosion;
    public GameObject overSelf;

    public BoxCollider2D enemyCollider;
    public BoxCollider2D enemyCollider2;

    // Use this for initialization
    void Start () {
        myRender = GetComponent<SpriteRenderer>();
	}


    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Destroy(gameObject);
            Destroy(enemyCollider);
            Destroy(enemyCollider2);
            Destroy(overSelf);
        }
    }
    // Update is called once per frame
    void Update () {
        currentScore = PlayerPrefs.GetFloat("Score");

       
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("purifierWave"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            Destroy(enemyCollider);
            Destroy(enemyCollider2);
            Destroy(overSelf);
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
}

