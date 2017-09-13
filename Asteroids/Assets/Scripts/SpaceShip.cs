using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour {

    private float speed = 1500;
    private float maxspeed = 100;

    private int xAxis = 5;

    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	

	void Update () {

        // Input Keys

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Right");
            transform.Rotate(0, 0, -xAxis);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Left");
            transform.Rotate(0, 0, xAxis);
        }

        // Boost

        if (Input.GetKey(KeyCode.Space) && rb.velocity.magnitude <= maxspeed)
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
        }


	}
}
