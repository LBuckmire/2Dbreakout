using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Script for the paddle inheriting the information from The_Base.Paddle
public class PaddMve : The_Base.Paddle
{ 

    // Use this for initialization
    protected override void Start() // Allows for access and the ability to add to the void Start created in the The_Base.Paddle class
    {
        base.Start();   // Calling the start set in The_Base.Paddle class
        rb2d = GetComponent<Rigidbody2D>(); // Connects the Rigidbody 2D once you add it from the inspector/IDE
    }

    // Update is called once per frame
    protected override void Update() // Allows for access and the ability to add to the void Update created in the The_Base.Paddle class
    {
        PaddMovement(); // Calling the function set in the The_Base.Paddle class  
    }
    
}