using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private int bulletSpeed;

	void Start () {
        bulletSpeed = 40;
	}
	
	void Update () {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroids")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Debug.Log("impact");
        }
    }

}
