using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    public Sprite shipIdle, shipMove;                                           // Sprites                                 
    private SpriteRenderer spriteRenderer;

    private float speed = 1500, maxspeed = 100, xAxis = 5;                      // Acceleration, MaxSpeed, xAxis Rotation

    public GameObject bulletPref;                                               // Bullet
    public Transform bulletSpawn;                                               // Spawn Position                                                  // Horizontal Rotation

    private AudioSource audioSP;
    private Rigidbody rb;
    private GameManager GM;                                                     // Calls GameManager Script

    public AudioClip fireSound;

    //private float timer;

    void Start()
    {
        //timer = 30;
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM = GameObject.Find("Main Camera").GetComponent<GameManager>();        // Get Main Camera Script    
        audioSP = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Input Keys

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -xAxis);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, xAxis);
        }

        // Boost and Sprite Changer

        if (Input.GetKey(KeyCode.Space) && rb.velocity.magnitude <= maxspeed)
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
            spriteRenderer.sprite = shipMove;
        }
        else
        {
            spriteRenderer.sprite = shipIdle;
        }

        // Fire Shooting

        if (Input.GetKeyDown(KeyCode.S))
        {
            Fire();
        }

        /*if(this.enabled == false)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            this.enabled = true;
            timer = 30;
        }*/
    }

    // Fire Method

    void Fire()
    {
        GameObject newBullet = Instantiate(bulletPref, bulletSpawn.Find("FireSpawn").position, bulletSpawn.rotation); // FireSpawn is son of SpaceShip
        audioSP.PlayOneShot(fireSound);
        Destroy(newBullet, 2.0f);
    }

    // Destroy, Instantiate, SpaceShip HUD

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            // Ships UI and GAME OVER

            if (GM.lifeShip_3.enabled == false && GM.lifeShip_2.enabled == false && GM.lifeShip_1.enabled == true)
            {
                GM.lifeShip_1.enabled = false;
                GM.txtGameOver.enabled = true;                                    // Show Game Over text
            }

            else if (GM.lifeShip_3.enabled == false && GM.lifeShip_2.enabled == true && GM.lifeShip_1.enabled == true)
            {
                GM.lifeShip_2.enabled = false;
                GM.spawnShip();
            }

            else if (GM.lifeShip_3.enabled == true && GM.lifeShip_2.enabled == true && GM.lifeShip_1.enabled == true)
            {
                GM.lifeShip_3.enabled = false;
                GM.spawnShip();
            }

            // Destroy Ship

            Destroy(other.gameObject);                                            // Destroy the Asteroid
            Destroy(gameObject);                                                  // Destroy the ship
            //this.enabled = false;
        }
    }
}

