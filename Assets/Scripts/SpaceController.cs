using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    public GameObject asteroids;
    //public GameObject[] asteroids;
    private int numbers;
    private Vector2 spawnPoint;

    public GameObject ship;

	void Start () {

        spawnShip();
        numbers = 1;
        //asteroids = GameObject.FindGameObjectsWithTag("Asteroids");
        //numbers = asteroids.Length;

    }
	
	void Update () {

        for(int i = 0; i < 20; i++)
        {
            InvokeRepeating("spawnAsteroids", 1f, 3f);
        }

    }

    void spawnAsteroids()
    {
        spawnPoint = new Vector2(Random.Range(-100, 100), Random.Range(-125, 125));

        //Instantiate(asteroids[UnityEngine.Random.Range(0, asteroids.Length - 1)], spawnPoint, Quaternion.identity);
        Instantiate(asteroids, spawnPoint, Quaternion.identity);
        CancelInvoke();
    }

    public void spawnShip()
    {
        Instantiate(ship, new Vector2(0, 0), Quaternion.identity);
    }
}
