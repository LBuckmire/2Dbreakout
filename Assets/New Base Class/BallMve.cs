using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The Script for the Ball inheriting the information from The_Base.Ball
public class BallMve : The_Base.Ball
{
    // Private variables (Not shown/editable in the inspector/IDE)
    private AudioSource audioSource;

    // Use this for initialization
    protected override void Start() // Allows for access and the ability to add to the void Start created in the The_Base.Ball class
    {
        base.Start(); // Calling the start set in The_Base.Ball class
        audioSource = GetComponent<AudioSource>(); // Attaches the AudioSource to gameobject this script is linked to
    }

    // Update is called once per frame
    protected override void Update() // Allows for access and the ability to add to the void Update created in the The_Base.Ball class
    {
        BallMovement(); // Calling the function set in the The_Base.Ball class 
    }

    // A function for declaring an object has collided with another
    void OnCollisionEnter2D(Collision2D SFXBallColl)
    {
        // Sets a condition that if the object hit is tagged "Brick" then the statement is activated
        if (SFXBallColl.gameObject.tag == "Brick")
        {
            audioSource.clip = AudioBrickHit; // The AudioSource will get the AudioBrickHit sound entered in the IDE
            audioSource.Play(); // The AudioSource will play the AudioBrickHit sound
        }

        // Sets a condition that if the object hit is tagged "Paddle" and/or "Border"
        if (SFXBallColl.gameObject.tag == "Paddle" || SFXBallColl.gameObject.tag == "Border")
        {
            audioSource.clip = AudioPaddleHit;  // The AudioSource will get the AudioPaddleHit sound entered in the IDE
            audioSource.Play(); // The AudioSource will play the AudioPaddleHit sound
        }
    }
}
