using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Image lifeShip_1;                                                // Ship Image HUD
    public Image lifeShip_2;                                                // Ship Image HUD
    public Image lifeShip_3;                                                // Ship Image HUD

    public Text txtGameOver;                                                // Game Over Text

    public GameObject asteroids;
    public GameObject ship;
    
    private Vector2 spawnPoint;                                             // Asteroid SpawnPoint

    public AudioClip destrAsteroid;                                         // Asteroid Destruction Sound
    private AudioSource audioGM;

	void Start () {

        InvokeRepeating("spawnAsteroids", 2f, 1f);                          // Instantiate Asteroids

        txtGameOver.enabled = false;                                        // HUD

        lifeShip_1.enabled = true;                                          // Ship Image HUD
        lifeShip_2.enabled = true;                                          // Ship Image HUD
        lifeShip_3.enabled = true;                                          // Ship Image HUD

        spawnShip();
        audioGM = GetComponent<AudioSource>();       
    }
	
	void Update () {

    }

    // Sounds

    public void sndAsteroid()
    {
        audioGM.PlayOneShot(destrAsteroid);
    }

    // Spawn Asteroids

    void spawnAsteroids()
    {
        spawnPoint = new Vector2(Random.Range(-100, 100), Random.Range(-125, 125));
        Instantiate(asteroids, spawnPoint, Quaternion.identity);
    }

    // Spawn the Ship

    public void spawnShip()
    {
        Instantiate(ship, new Vector2(0, 0), Quaternion.identity);
    }

    // Show Game Over Text

    public void GameOver()
    {
        txtGameOver.enabled = true;
    }

}
