using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    private float speed = 1500;
    private float maxspeed = 100;

    public GameObject bulletPref;
    public Transform bulletSpawn;

    private int xAxis = 5;                                       // Horizontal Rotation

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	

	void Update () {

        // Input Keys

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, -xAxis);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, xAxis);
        }

        // Boost

        if (Input.GetKey(KeyCode.Space) && rb.velocity.magnitude <= maxspeed)
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Fire();
        }


	}

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPref, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 6;
        Destroy(bullet, 2.0f);
    }
}
