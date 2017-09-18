using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : MonoBehaviour {

    private bool move;
    private int speed;                                                  // Center Point Speed

	void Start () {

        speed = 0;                                                      // Set a number value to move the CenterPoint
        InvokeRepeating("Switch", 0f, 2f);                              
    }
	
	void Update () {

        if (move)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);          
        } else {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    void Switch()                                                       // Switch between true/false
    {
        move = !move;
    }
}
