using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private float speed;

    private Rigidbody rb;
    private Vector2 direction;

    //private GameObject center;
    public Transform center;

    void Start () {


        //center = GameObject.Find("CenterPoint");
        //Debug.Log(center);
        speed = Random.Range(100.0f, 500.0f);
        rb = GetComponent<Rigidbody>();

        //direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        //direction = new Vector2(gameObject.transform.position.x * -1 * Time.deltaTime, gameObject.transform.position.y * -1 * Time.deltaTime);
        //direction = new Vector2(center.transform.position.x * -1 * Time.deltaTime, center.transform.position.y * -1 * Time.deltaTime);
        //rb.AddForceAtPosition(direction * speed, transform.position);
        //rb.velocity = new Vector2(center.position.x, center.position.y);
    }
	

	void Update () {

        //transform.position = Vector3.MoveTowards(transform.position, center.position, 5 * Time.deltaTime);
        rb.AddForce(-center.position.x, -center.position.y, 0);
    }
}
