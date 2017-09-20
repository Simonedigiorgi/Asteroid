using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    private float speed;                                                        // Asteroids Speed
    public float healts = 3;                                                    // Asteroid Healt

    public Transform center;                                                    // Asteroid follow the Center Point

    private GameManager GM;                                                     // Get the GameManager Script

    void Start()
    {
        GM = GameObject.Find("Main Camera").GetComponent<GameManager>();
        speed = Random.Range(3.0f, 8.0f);                                       // Random Speed             
    }

    void Update() {

        // Move the Asteroid

        transform.position = Vector3.MoveTowards(transform.position, center.position, speed * Time.deltaTime);

        // Destroy the Asteroid

        if (healts <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Decrease Asteroid Healt

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            healts--;
        }
    }

    // Asteroid Sound

    private void OnDestroy()
    {
        // Asteroid Sound (is inside the TRY because if is not you get an error)

        try
        {
            GM.sndAsteroid();
        }
        catch (System.Exception)
        {

        }
    }
}
