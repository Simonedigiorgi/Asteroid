using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private float speed;

    private Vector2 direction;
    public Transform center;

    void Start()
    {
        speed = Random.Range(1.0f, 5.0f);

        //direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        //direction = new Vector2(gameObject.transform.position.x * -1 * Time.deltaTime, gameObject.transform.position.y * -1 * Time.deltaTime);
        //direction = new Vector2(center.transform.position.x * -1 * Time.deltaTime, center.transform.position.y * -1 * Time.deltaTime);
    }

        void Update() {

            transform.position = Vector3.MoveTowards(transform.position, center.position, speed * Time.deltaTime);
        }
}
