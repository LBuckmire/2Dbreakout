// Liam .......
// Base Class For Inheritance
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Class : MonoBehaviour
{
    #region Paddle Variables
    protected float paddle_Speed;      // Speed of th paddle which moves along the X axis

    protected Vector3 mvelocity = Vector3.zero;     // Vector3 that starts at 0 and can be manipulated over time
    #endregion

    // Use this for initialization
    void Start ()
    {
        paddle_Speed = 5f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Functions
        Movement();
        Paddle_Restriction();
	}
    #region Paddle Movement Functions
    protected virtual void Movement()
    {
        float xMove = Input.GetAxis("Horizontal") * paddle_Speed * Time.deltaTime;      // Declaring a Input That moves with Value Speed and with time
        mvelocity = new Vector3(xMove, 0, 0);                       // Restricting the Paddle so it cannot go beyond points and moving with input float

        transform.position += mvelocity;
    }

    protected virtual void Paddle_Restriction()
    {
        if(transform.position.x >= 10)      // If the transform of the GameObject is = to 10
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);       // GameObject cannot go past position 10f om the X axis
        }
        else if(transform.position.x <= -10f)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
    }
    #endregion
}
