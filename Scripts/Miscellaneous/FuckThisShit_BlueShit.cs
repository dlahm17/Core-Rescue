using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuckThisShit_BlueShit : MonoBehaviour
{
    public GameObject armor;
    public GameObject speedup;
    public GameObject pt1;
    public GameObject gun;
    public GameObject rocket;
    public GameObject laser;
    public GameObject purifier;
    public GameObject healer;

    private float RandNumForItems;
    private float health;
    public Transform me;
    public Transform self;
    public Color32 hurtColor;
    public Color32 normalColor;
    public float HurtTime;
    private SpriteRenderer myRender;

    private bool amDed;
    // Use this for initialization
    void Start()
    {
        amDed = false;
        myRender = GetComponent<SpriteRenderer>();
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && amDed == false)
        {
            RandNumForItems = Random.Range(0, 21);
            spawn();
            amDed = true;
            Destroy(gameObject);
        }
    }
    void spawn()
    {
        if (RandNumForItems <= 5)
        {
            Instantiate(gun, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 9 && RandNumForItems > 5)
        {
            Instantiate(rocket, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 14 && RandNumForItems > 9)
        {
            Instantiate(laser, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 16 && RandNumForItems > 14)
        {
            Instantiate(speedup, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 17 && RandNumForItems > 16)
        {
            Instantiate(purifier, me.position, Quaternion.Euler(0, 0, 0));

        }
        if (RandNumForItems <= 18 && RandNumForItems > 17)
        {
            Instantiate(pt1, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 19 && RandNumForItems > 18)
        {
            Instantiate(healer, me.position, Quaternion.Euler(0, 0, 0));
        }
        if (RandNumForItems <= 20 && RandNumForItems > 19)
        {
            Instantiate(armor, me.position, Quaternion.Euler(0, 0, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
            if (other.gameObject.tag.Equals("purifierWave"))
            {
                
                Destroy(gameObject);
            }
            if (other.gameObject.tag.Equals("EnemyStopper"))
            {
                Destroy(gameObject);
            }
            if (other.gameObject.tag.Equals("Player"))
            {
               
                Destroy(gameObject);
            }
            if (other.gameObject.tag.Equals("Sm_laser"))
            {
                health = health - 25;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Lg_Laser"))
            {
                health = health - 100;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Md_Laser"))
            {
                health = health - 35;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Sm_Rocket"))
            {
                health = health - 15;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Md_Rocket"))
            {
                health = health - 20;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Lg_Rocket"))
            {
                health = health - 25;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Sm_bullet"))
            {
                health = health - 5;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Md_bullet"))
            {
                health = health - 7;
                StartCoroutine("flashRedOnHit");
            }
            if (other.gameObject.tag.Equals("Lg_bullet"))
            {
                health = health - 10;
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
       
