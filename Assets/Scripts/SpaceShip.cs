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

    private Rigidbody rb;
    private SpaceController sc;                                                 // Calls SpaceController Script

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sc = GameObject.Find("Main Camera").GetComponent<SpaceController>();    // Get Main Camera Script        
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
    }

    // Fire Method

    void Fire()
    {
        GameObject newBullet = Instantiate(bulletPref, bulletSpawn.FindChild("FireSpawn").position, bulletSpawn.rotation);
        Destroy(newBullet, 2.0f);
    }

    // Destroy and Instantiate

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            sc.spawnShip();
        }
    }

}

