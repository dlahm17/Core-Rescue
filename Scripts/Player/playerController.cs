using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    private float currentSpeed;

    public AudioSource bulletAudio;
    public AudioSource rocketAudio;
    public AudioSource laserAudio;

    private Renderer myRender;
    private string currentLevel;

    public Color32 normalColor;
    public Color32 DashColor;
    public Color32 hurtColor;
    public float hurtTime;
    public float HurtTime;
    private float currentScore;
    public GameObject Self;


    private BoxCollider2D mycollider;

    //for movement speed
    public float speed;
    private Rigidbody2D myRB; 
    public float dashSpeed;
    
    //for health
    public Slider healthSlider;
    private int health = 100;
    private bool canBeHurt;
    public GameObject deathScreen;
    public GameObject gameOverScreen;
    public Transform deathScreenPos;

    //for movement abilities
    private int agility = 100;
    public Slider agilitySlider;
    public float agilityReload;
    public float timeToMove;
    public float moveTime;
    public float dashTime;
    public float timetoReloadAgility;


    //for items
    public GameObject enemyKiller;
    public float armorTimer;
    public float armorTime;
    private bool armorActive;
    public Color32 armorColor;


    //for purifiers (flashes like gungeon)
    private int purifiers;
    private int currentPurifiers;
    public float useTimer;
    public float timeToUse;

    //bools for shooting types and defining what gets shot
  //  private bool gun1;
 //   private bool gun2;
 //   private bool gun3;
  //  private bool gun4;
 //   private bool gun5;
 //   private bool laser1;
 //   private bool laser2;
  //  private bool laser3;
  //  private bool laser4;
 //   private bool laser5;
 //   private bool rockets1;
 //   private bool rockets2;
 //   private bool rockets3;
 //   private bool rockets4;
 //   private bool rockets5;

    private int gunShoot;
    private int laserShoot;
    private int rocketShoot;

    //for reloading
    public float reloadTime;
    public float timeToReload;
    public float timetoReloadLaser;
    public float timetoReloadRockets;

    //different projectiles you can fire
    public GameObject Sm_Bullet;
    public GameObject Sm_Bullet_45;
    public GameObject Sm_Bullet_N45;
    public GameObject Md_Bullet;
    public GameObject Md_Bullet_45;
    public GameObject Md_Bullet_N45;
    public GameObject Lg_Bullet;
    public GameObject Lg_Bullet_45;
    public GameObject Lg_Bullet_N45;
    public GameObject Sm_Laser;
    public GameObject Sm_Laser2;
    public GameObject Sm_Laser3;
    public GameObject Md_Laser;
    public GameObject Md_Laser2;
    public GameObject Md_Laser3;
    public GameObject Lg_Laser;
    public GameObject Sm_Rocket;
    public GameObject Sm_Rocket_45;
    public GameObject Sm_Rocket_N45;
    public GameObject Md_Rocket;
    public GameObject Md_Rocket_45;
    public GameObject Md_Rocket_N45;
    public GameObject Lg_Rocket;
    public GameObject Lg_Rocket_45;
    public GameObject Lg_Rocket_N45;

    
    
    //for shooting positions
    public Transform gunPos1;
    public Transform gunPos1_1;
    public Transform gunPos1_2;
    public Transform gunPos1_3;
    public Transform gunPos2;
    public Transform gunPos2_1;
    public Transform gunPos3;
    public Transform gunPos3_1;
    public Transform gunPos4;
    public Transform gunPos4_1;
    public Transform gunPos5;
    public Transform gunPos5_1;
    public Transform laserPos1;
    public Transform laserPos2;
    public Transform laserPos3;
    public Transform rocketPos1;
    public Transform rocketPos1_1;
    public Transform rocketPos2;
    public Transform rocketPos2_1;
    public Transform rocketPos3;
    public Transform rocketPos3_1;
    public Transform rocketPos4;
    public Transform rocketPos4_1;
    public Transform rocketPos5;
    public Transform rocketPos5_1;
    public Transform RocketStandard;


    public GameObject impactExplosion;
    public Transform player;

    private int currentlives;

    public Color32 deadColor;

    private bool amDed;
    private bool canShoot;
   


    void Start()
    {
        canShoot = true;
        currentSpeed = speed;
        amDed = false;
        health = 100;
        agility = 100;
        mycollider = GetComponent<BoxCollider2D>();
        myRender = GetComponent<Renderer>();
        //these will be commented out once I can
        laserShoot = 0;
        rocketShoot = 0;
        gunShoot = 1;
        //comment this out okay?  Make the new game have a Gunshoot = 1

        StartCoroutine("retryShooter");
        canBeHurt = true;
    //    gun1 = true;
        myRB = GetComponent<Rigidbody2D>();
    }



    IEnumerator waitforDeath()
    {
        //insert death anim here
        yield return new WaitForSeconds(2);
        if (PlayerPrefs.GetInt("Lives") == 0)
        {

            Destroy(gameObject);
            Instantiate(gameOverScreen, deathScreenPos.position, Quaternion.Euler(0, 0, 0));
        }
        else
        {
            canShoot = false;
            mycollider.enabled = false;
            myRender.material.color = deadColor;
            currentlives = currentlives - 1;
            PlayerPrefs.SetInt("Lives", currentlives);
            speed = 0;
            PlayerPrefs.SetInt("gunShooter", 1);
            PlayerPrefs.SetInt("rocketShooter", 0);
            PlayerPrefs.SetInt("laserShooter", 0);
            yield return new WaitForSeconds(2);
            health = 100;
            agility = 100;
            myRender.material.color = normalColor;
            mycollider.enabled = true;
            amDed = false;
            speed = currentSpeed;
            canBeHurt = false;
            yield return new WaitForSeconds(1);
            canBeHurt = true;
            canShoot = true;
                

        }
    }


    
    private void FixedUpdate()
    {


        if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") > 0)
        {

            //insert anim here
            transform.Translate(new Vector2(1 / 2, 1 / 2) * speed   );

        }
        if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") < 0)
        {

            //insert anim here
            transform.Translate(new Vector2(-1 / 2, 1 / 2) * speed);

        }
        if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") > 0)
        {

            //insert anim here
            transform.Translate(new Vector2(1 / 2, -1 / 2) * speed);

        }
        if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") < 0)
        {

            //insert anim here
            transform.Translate(new Vector2(-1 / 2, -1 / 2) * speed);

        }
        if (Input.GetAxisRaw("Vertical") > 0)

        {

            //insert anim here
            transform.Translate(Vector2.up * speed);

        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {

            //insert anim here
            transform.Translate(Vector2.down * speed);

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {


            //insert anim here
            transform.Translate(Vector2.right * speed);

        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {

            //insert anim here
            transform.Translate(Vector2.left * speed);

        }
        if (Input.GetAxisRaw("Fire1") > 0 && canShoot == true)
        {
            Debug.Log("Fire");
            //no anim needed
            fire();
        }
        if (Input.GetAxisRaw("Fire2") > 0)
        {
            Debug.Log("Dash");
            //put anim in Dash() function
            dash();
        }
        if (Input.GetAxisRaw("Jump") > 0)
        {
            Debug.Log("Special");
            //put anim in the flip() function
            special();
        }
        if (Input.GetAxisRaw("Fire3") > 0 && Time.timeSinceLevelLoad >= timeToUse)
        {
            Debug.Log("Use Item");
            //no anim needed
            useItem();
            timeToUse = Time.timeSinceLevelLoad + useTimer;
        }
        if (Time.timeSinceLevelLoad >= agilityReload && agility <= 100)
        {
            agility = agility + 1;
            agilitySlider.value = agility;
        }


        if (armorActive == true)
        {
            canBeHurt = false;
        }
        currentScore = PlayerPrefs.GetFloat("Score"); 
    }

    


    void Update()
    {
        healthSlider.value = health;
        agilitySlider.value = agility;
        currentlives = PlayerPrefs.GetInt("Lives");
        if (health <= 0 && amDed == false)
        {
            amDed = true;
            StartCoroutine("waitforDeath");

        }

      
    }

  


    //in order to use an item one needs to be 'loaded'
    void useItem()
   {

        if (currentPurifiers >= 1)
        {
            currentPurifiers = currentPurifiers - 1;
            PlayerPrefs.SetFloat("Purifier", currentPurifiers);
            Instantiate(enemyKiller, gunPos1.position, Quaternion.Euler(0, 0, 0));
        }
       
        
    }
 


    //for firing different projectiles
    void fire()
    {
   
        if (PlayerPrefs.GetInt("gunShooter")==1 && Time.timeSinceLevelLoad >= reloadTime)
        {
           bulletAudio.PlayOneShot(bulletAudio.clip, 1);
            Debug.Log("Shooting1");
            Instantiate(Sm_Bullet, gunPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Bullet, gunPos1_1.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timeToReload;
        }
        if (PlayerPrefs.GetInt("gunShooter")==2 && Time.timeSinceLevelLoad >= reloadTime)
        {
            Debug.Log("Shooting2");
            bulletAudio.PlayOneShot(bulletAudio.clip, 1);
            Instantiate(Sm_Bullet, gunPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Bullet, gunPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Bullet, gunPos2.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Bullet, gunPos3.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timeToReload;
        }
        if (PlayerPrefs.GetInt("gunShooter")==3 && Time.timeSinceLevelLoad >= reloadTime)
        {
            Debug.Log("Shooting3");
            bulletAudio.PlayOneShot(bulletAudio.clip, 1);
            Instantiate(Md_Bullet, gunPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Bullet, gunPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Bullet_45, gunPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Bullet_45, gunPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Bullet_N45, gunPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Bullet_N45, gunPos3_1.position, Quaternion.Euler(0, 0, -45));
            reloadTime = Time.timeSinceLevelLoad + timeToReload;
        }
        if (PlayerPrefs.GetInt("gunShooter")==4 && Time.timeSinceLevelLoad >= reloadTime)
        {
            bulletAudio.PlayOneShot(bulletAudio.clip, 1);
            Debug.Log("Shooting4");
            Instantiate(Md_Bullet, gunPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Bullet, gunPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Bullet_45, gunPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Bullet_45, gunPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Bullet_N45, gunPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Bullet_N45, gunPos3_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Bullet, gunPos4.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Bullet, gunPos5.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timeToReload;
        }
        if (PlayerPrefs.GetInt("gunShooter")>= 5 && Time.timeSinceLevelLoad >= reloadTime)
        {
            bulletAudio.PlayOneShot(bulletAudio.clip, 1);
            Debug.Log("Shooting5");
            Instantiate(Lg_Bullet, gunPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Bullet, gunPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Bullet, gunPos1_2.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Bullet, gunPos1_3.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Bullet_45, gunPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Bullet_45, gunPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Bullet_N45, gunPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Bullet_N45, gunPos3_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Bullet_45, gunPos4.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Bullet_45, gunPos4_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Bullet_N45, gunPos5.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Bullet_N45, gunPos5_1.position, Quaternion.Euler(0, 0, -45));
            reloadTime = Time.timeSinceLevelLoad + timeToReload;
        }
        if (PlayerPrefs.GetInt("rocketShooter")==1 && Time.timeSinceLevelLoad >= reloadTime)
        {
            rocketAudio.PlayOneShot(rocketAudio.clip, 1);
            Instantiate(Sm_Rocket, RocketStandard.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadRockets;
        }
        if (PlayerPrefs.GetInt("rocketShooter")==2 && Time.timeSinceLevelLoad >= reloadTime)
        {
            rocketAudio.PlayOneShot(rocketAudio.clip, 1);
            Instantiate(Sm_Rocket, rocketPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Rocket, rocketPos1_1.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadRockets;
        }
        if (PlayerPrefs.GetInt("rocketShooter")==3 && Time.timeSinceLevelLoad >= reloadTime)
        {
            rocketAudio.PlayOneShot(rocketAudio.clip, 1);
            Instantiate(Sm_Rocket, rocketPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Rocket, rocketPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Rocket_45, rocketPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Sm_Rocket_45, rocketPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Sm_Rocket_N45, rocketPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Sm_Rocket_N45, rocketPos3_1.position, Quaternion.Euler(0, 0, -45));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadRockets;
        }
        if (PlayerPrefs.GetInt("rocketShooter")==4 && Time.timeSinceLevelLoad >= reloadTime)
        {
            rocketAudio.PlayOneShot(rocketAudio.clip, 1);
            Instantiate(Md_Rocket, rocketPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Rocket, rocketPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Rocket_45, rocketPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Rocket_45, rocketPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Rocket_N45, rocketPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Rocket_N45, rocketPos3_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Rocket_N45, rocketPos4.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Rocket_N45, rocketPos4_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Md_Rocket_45, rocketPos5.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Md_Rocket_45, rocketPos5_1.position, Quaternion.Euler(0, 0, 45));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadRockets;
        }
        if (PlayerPrefs.GetInt("rocketShooter")>= 5 && Time.timeSinceLevelLoad >= reloadTime)
        {
            rocketAudio.PlayOneShot(rocketAudio.clip, 1);
            Instantiate(Lg_Rocket, RocketStandard.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Rocket, rocketPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Rocket, rocketPos1_1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Lg_Rocket_45, rocketPos2.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Rocket_45, rocketPos2_1.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Rocket_N45, rocketPos3.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Rocket_N45, rocketPos3_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Rocket_N45, rocketPos4.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Rocket_N45, rocketPos4_1.position, Quaternion.Euler(0, 0, -45));
            Instantiate(Lg_Rocket_45, rocketPos5.position, Quaternion.Euler(0, 0, 45));
            Instantiate(Lg_Rocket_45, rocketPos5_1.position, Quaternion.Euler(0, 0, 45));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadRockets;
        }
        if (PlayerPrefs.GetInt("laserShooter")==1 && Time.timeSinceLevelLoad >= reloadTime)
        {
            laserAudio.PlayOneShot(laserAudio.clip, 1);
            Instantiate(Sm_Laser, laserPos1.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadLaser;
        }
        if (PlayerPrefs.GetInt("laserShooter")==2 && Time.timeSinceLevelLoad >= reloadTime)
        {
            laserAudio.PlayOneShot(laserAudio.clip, 1);
            Instantiate(Md_Laser, laserPos1.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadLaser;
        }
        if (PlayerPrefs.GetInt("laserShooter")==3 && Time.timeSinceLevelLoad >= reloadTime)
        {
            laserAudio.PlayOneShot(laserAudio.clip, 1);
            Instantiate(Md_Laser, laserPos1.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Laser2, laserPos2.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Sm_Laser3, laserPos3.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadLaser;
        }
        if (PlayerPrefs.GetInt("laserShooter")==4 && Time.timeSinceLevelLoad >= reloadTime)
        {
            laserAudio.PlayOneShot(laserAudio.clip, 1);
            Instantiate(Md_Laser2, laserPos2.position, Quaternion.Euler(0, 0, 0));
            Instantiate(Md_Laser3, laserPos3.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadLaser;
        }
        
        if (PlayerPrefs.GetInt("laserShooter")>=5 && Time.timeSinceLevelLoad >= reloadTime)
        {
            laserAudio.PlayOneShot(laserAudio.clip, 1);
            Instantiate(Lg_Laser, laserPos1.position, Quaternion.Euler(0, 0, 0));
            reloadTime = Time.timeSinceLevelLoad + timetoReloadLaser;
        }

    }


     
    void dash ()
    {
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical")> 0 && Input.GetAxisRaw("Horizontal") > 0)
        {
            mycollider.enabled = false;
            Debug.Log("Moving");
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(1 * dashSpeed, 1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopUpRightDash");
            
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") < 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(-1 * dashSpeed, 1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopUpLeftDash");
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") > 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(1 * dashSpeed, -1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopDownRightDash");
            
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") < 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(-1 * dashSpeed, -1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopDownLeftDash");
           
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical") > 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(0, 1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopUpDash");
            

        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Vertical") < 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(0, -1 * dashSpeed));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopDownDash");
           
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Horizontal") > 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(1 * dashSpeed, 0));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopRightDash");
           
        }
        if (agility >= 5 && Time.time >= moveTime && Input.GetAxisRaw("Horizontal") < 0)
        {
            mycollider.enabled = false;
            StartCoroutine("flashWhiteforDash");
            canBeHurt = false;
            agility = agility - 5;
            agilitySlider.value = agility;
            myRB.AddForce(new Vector2(-1 * dashSpeed, 0));
            moveTime = Time.time + timeToMove;
            agilityReload = Time.time + timetoReloadAgility;
            StartCoroutine("stopLeftDash");
            
        }
    }
   IEnumerator flashWhiteforDash()
    {
        myRender.material.color = DashColor;
        yield return new WaitForSeconds(hurtTime);
        myRender.material.color = normalColor;
    }
    IEnumerator stopUpRightDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(-1 * dashSpeed, -1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;

    }
    IEnumerator stopUpLeftDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(1 * dashSpeed, -1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopDownRightDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(-1 * dashSpeed, 1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopDownLeftDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(1 * dashSpeed, 1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopUpDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(0, -1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopDownDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(0, 1 * dashSpeed));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopRightDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(-1 * dashSpeed,0));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator stopLeftDash()
    {
        yield return new WaitForSeconds(dashTime);
        myRB.AddForce(new Vector2(1 * dashSpeed,0));
        canBeHurt = true;
        mycollider.enabled = true;
    }
    IEnumerator armorStart()
    {
        armorActive = true;
        yield return new WaitForSeconds(armorTimer);
        canBeHurt = true;
        armorActive = false;

    }
    IEnumerator armorColorChanger()
    {
        myRender.material.color = armorColor;
        yield return new WaitForSeconds(armorTime);
        myRender.material.color = normalColor;
        yield return new WaitForSeconds(armorTime);
        if (armorActive == true)
        {
            StartCoroutine("armorColorChanger");
        }
       
    }

    private void special()
    {
       //insert special ability, going to need extra scripts for every specific ship
        
    }
   
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemyProjectile1") && canBeHurt == true)
        {
            health = health - 5;
            healthSlider.value = health;
            Destroy(other.gameObject);
            StartCoroutine("flashRedForPain");
        }
        if (other.gameObject.tag.Equals("enemyProjectile2") && canBeHurt == true)
        {
            health = health - 10;
            healthSlider.value = health;
            Destroy(other.gameObject);
            StartCoroutine("flashRedForPain");
        }
        if (other.gameObject.tag.Equals("enemyProjectile3") && canBeHurt == true)
        {
            health = health - 15;
            healthSlider.value = health;
            Destroy(other.gameObject);
            StartCoroutine("flashRedForPain");
        }
        if (other.gameObject.tag.Equals("Enemy") && canBeHurt == true)
        {
            Instantiate(impactExplosion, player.position, Quaternion.Euler(0, 0, 0));
            health = health - 5;
            healthSlider.value = health;
            StartCoroutine("flashRedForPain");
        }
        if (other.gameObject.tag.Equals("Fire")&& canBeHurt == true)
        {
            Instantiate(impactExplosion, player.position, Quaternion.Euler(0, 0, 0));
            health = health - 10;
            healthSlider.value = health;
            StartCoroutine("flashRedForPain");
        }
        //for item pickups
        if (other.gameObject.tag.Equals("Purifier"))
        {

            if (currentPurifiers < 3)
            {
                Destroy(other.gameObject);
                currentPurifiers = currentPurifiers + 1;
                PlayerPrefs.SetFloat("Purifier", currentPurifiers);
            }
            if (currentPurifiers == 3)
            {
                Destroy(other.gameObject);
            }

        }
        if (other.gameObject.tag.Equals("Armor"))
        {
            //use printing function here
            canBeHurt = false;
            StartCoroutine("armorStart");
            StartCoroutine("armorColorChanger");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("Healer"))
        {
           if (health <= 50)
            {
                health = health + 50;
                healthSlider.value = health;
            }
            else
            {
                health = 100;
                healthSlider.value = health;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("Speeder"))
        {
            speed = speed*2;
            Destroy(other.gameObject);
            StartCoroutine("stopSpeed");
        }

        //for getting hurt and getting health given back 

  
        //for picking up items
        if (other.gameObject.tag.Equals("gunPickup"))
        {
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);

            gunShoot = gunShoot + 1;
            laserShoot = 0;
            rocketShoot = 0;
            retryShooter();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("laserPickup"))
        {
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);

            laserShoot = laserShoot + 1;
            gunShoot = 0;
            rocketShoot = 0;
            retryShooter();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("rocketPickup"))
        {
            currentScore = currentScore + 100;
            PlayerPrefs.SetFloat("Score", currentScore);

            rocketShoot = rocketShoot + 1;
            laserShoot = 0;
            gunShoot = 0;
            retryShooter();
            Destroy(other.gameObject);
        }

    
}
    void retryShooter()
    {
        PlayerPrefs.SetInt("gunShooter", gunShoot);
        PlayerPrefs.SetInt("laserShooter", laserShoot);
        PlayerPrefs.SetInt("rocketShooter", rocketShoot);
    }
    IEnumerator stopSpeed()
    {
        yield return new WaitForSeconds(5);
        speed = speed/2;
    }
    IEnumerator flashRedForPain()
    {
        myRender.material.color = hurtColor;
        yield return new WaitForSeconds(HurtTime);
        myRender.material.color = normalColor;
    }
    


   
}
