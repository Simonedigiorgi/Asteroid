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

    private bool isLife3;                                                       // HUD bool Ship
    private bool isLife2;                                                       // HUD bool Ship
    private bool isLife1;                                                       // HUD bool Ship

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GM = GameObject.Find("Main Camera").GetComponent<GameManager>();        // Get Main Camera Script    
        audioSP = GetComponent<AudioSource>();

        isLife3 = GM.lifeShip_3.enabled;
        isLife2 = GM.lifeShip_2.enabled;
        isLife1 = GM.lifeShip_1.enabled;
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
            GameObject newBullet = Instantiate(bulletPref, bulletSpawn.Find("FireSpawn").position, bulletSpawn.rotation); // FireSpawn is son of SpaceShip
            audioSP.PlayOneShot(fireSound);
            Destroy(newBullet, 2.0f);
        }
    }

    // Destroy, Instantiate, SpaceShip HUD

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            // Ships UI and GAME OVER

            if (!isLife3 && !isLife2 && isLife1)
            {
                GM.lifeShip_1.enabled = false;
                GM.txtGameOver.enabled = true;                                     // Show Game Over text
            }

            else if (!isLife3 && isLife2 && isLife1)
            {
                GM.lifeShip_2.enabled = false;
                StartCoroutine(WaitForRespwan());
            }

            else if (isLife3 && isLife2 && isLife1)
            {
                GM.lifeShip_3.enabled = false;
                StartCoroutine(WaitForRespwan());
            }

            Destroy(other.gameObject);                                            // Destroy the Asteroid
            this.enabled = false;                                                 // Disable the Ship
            transform.position = new Vector3(2000, 0, 0);                         // Set the Ship far from the Scene
        }
    }

    IEnumerator WaitForRespwan()
    {
        yield return new WaitForSeconds(2);
        GM.spawnShip();
    }
}

