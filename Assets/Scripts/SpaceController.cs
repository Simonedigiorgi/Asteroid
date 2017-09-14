using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    public GameObject[] asteroids;
    private int numbers;
    private Vector2 spawnPoint;

	void Start () {

        asteroids = GameObject.FindGameObjectsWithTag("Asteroids");
        numbers = asteroids.Length;
    }
	
	void Update () {

        if (numbers != 20)
        {
            InvokeRepeating("spawnAsteroids", 1f, 3f);
        }
    }

    void spawnAsteroids()
    {
        spawnPoint = new Vector2(Random.Range(-100, 100), Random.Range(-125, 125));

        Instantiate(asteroids[UnityEngine.Random.Range(0, asteroids.Length - 1)], spawnPoint, Quaternion.identity);
        CancelInvoke();
    }
}
