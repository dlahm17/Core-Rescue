using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Basic : MonoBehaviour {

    //for shooting/health
    public float health;
    public float reload;
    public float reloadTime;

    private float burstDir;
    private float currentScore;




    //for damage taking
    public Renderer myRender;
    public Color32 hurtColor;
    public Color32 normalColor;

    public GameObject alsoMe;


    //for shooting and getting hurt
    public GameObject projectile;
    public Transform gunPos;
    public Transform gunPos2;
    public GameObject explosion;
    

    //for getting hit and dying

    private BoxCollider2D myCollider;
    private GameObject player;
    public Transform self_pos;
    public float HurtTime;

    private bool myDeath;
    private Transform Player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        myCollider = GetComponent<BoxCollider2D>();
        reload = Time.time + reload;
	}
	
	// Update is called once per frame
	void Update () {
       if (health <= 0)
        {
            currentScore = PlayerPrefs.GetFloat("Score");
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            Destroy(alsoMe);
        }
    }
    private void FixedUpdate()
    {
        Player = player.transform;
        Vector3 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward / 2);
        burstDir = angle + 90;
        if (Time.time >= reload)
        {
            
            Instantiate(projectile, gunPos.position, Quaternion.Euler(0,0, angle + 90));
            Instantiate(projectile, gunPos2.position, Quaternion.Euler(0, 0, angle + 90));
            reload = Time.time + reloadTime;
            StartCoroutine("shootMulti");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("purifierWave"))
        {
            Instantiate(explosion, self_pos.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);

            Destroy(alsoMe);
        }
        if (other.gameObject.tag.Equals("EnemyStopper"))
        {

            Destroy(alsoMe);
            Destroy(gameObject);
        }
        if (other.gameObject.tag.Equals("Player"))
        {

            Destroy(alsoMe);
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
    IEnumerator shootMulti()
    {
        yield return new WaitForSeconds(HurtTime);
        Instantiate(projectile, gunPos.position, Quaternion.Euler(0, 0, burstDir));
        Instantiate(projectile, gunPos2.position, Quaternion.Euler(0, 0, burstDir));
        yield return new WaitForSeconds(HurtTime);
        Instantiate(projectile, gunPos.position, Quaternion.Euler(0, 0, burstDir));
        Instantiate(projectile, gunPos2.position, Quaternion.Euler(0, 0, burstDir));

    }
}
