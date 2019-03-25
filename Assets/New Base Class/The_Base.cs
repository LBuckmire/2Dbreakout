//  Liam Buckmire
//  Base Class
/// <summary>
/// The basis for the scripts in these classes were based on scripts found in the "2D Breakout Example Project" in the Unity store
/// Credit to Danar Kayfi
/// Link found below 
/// <see cref="https://assetstore.unity.com/packages/templates/packs/2d-breakout-example-project-107757"/>
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The_Base : MonoBehaviour
{


    // Use this for initialization
    void Start ()
    {
		
	}

    #region Ball Class
    // The script for the Ball, inheriting from The_Base class, but can be used in other child classes
    public abstract class Ball : The_Base 
    {

        #region Ball Variables      

        // Protected variables - Allows for access to these variables through this or derived clases

        [SerializeField]    // Allows for the variable to be visible in the inspector/IDE from the base/derived class
        protected float Velocityball = 600f; // Sets the velocity of the ball at the start
        protected float MaxVel = 200f;  // Setting maximum velocity of the ball 
        [SerializeField]    // Allows for the variable to be visible in the inspector/IDE from the base/derived class
        protected AudioClip AudioBrickHit;  //  Variable to allow audio on the brick being hit
        [SerializeField]    // Allows for the variable to be visible in the inspector/IDE from the base/derived class
        protected AudioClip AudioPaddleHit; //  Variable allows for audio on paddle hit 
        

        // Private variables (Not shown/editable in the inspector/IDE)

        private Rigidbody2D rb2d; // Declaring a variable which will be assigned as the rigidbody
        private bool InPlayball; // A true or false statement to declare when the ball is in play
        
        #endregion

        protected new virtual void Start()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();  // Connects the Rigidbody 2D once you add it from the inspector/IDE
            
        }


        protected virtual void Update()
        {
            BallMovement(); // Calls the BallMovement function which i created and checks it once per frame 
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, MaxVel); // Clamp the maximum velocity of the GameObject so it doesn't go over a value set at 200
        }

        #region BallMovement
        protected virtual void BallMovement()   // Void to declare the Ball Movement function
        {
            // Declaring that if the "Jump" button is pressed & the ball isn't in play
            if (Input.GetButtonDown("Jump") && InPlayball == false)  
            {
                transform.parent = null;    // it detatches the ball from the parent (Paddle)
                InPlayball = true; // The ball is moving
                rb2d.isKinematic = false;   // Means the rigidbody has set so it is not kinematic so that it uses physics

                // Sets a condition within the current condition that if the paddle/ball is set 0 (stationary/standing still)
                if (Input.GetAxis("Horizontal") == 0f) 
                    // If the condition is met it applies force to the ball
                    rb2d.AddForce(new Vector2(1f, Velocityball));
                // Sets a condition that if the previous condition isn't met and the paddle/ball is greater than 0 
                else if (Input.GetAxis("Horizontal") > 0f)
                    // if this condition is met, it returns the velocity of the ball in all relevant vector position
                    rb2d.AddForce(new Vector2(Velocityball, Velocityball));
                // Sets a condition that if the previous condition isn't met and the paddle/ball is less than 0
                else if (Input.GetAxis("Horizontal") < 0f)
                    // if this condition is met, it returns the velocity of the ball in all relevant vector positions
                    rb2d.AddForce(new Vector2(-Velocityball, Velocityball));
            }

        }
        #endregion

    }
    #endregion

    #region Paddle Class
    // The script for the Paddle, inheriting from The_Base class, but can be used in other child classes
    public abstract class Paddle : The_Base 
    {
        [System.Serializable] // Allows for the class to be saved and loaded in Unity in the same state 
        public class Boundary   // A class that is created, inherited from the paddle class, designed to create boundaries
        {
            public float xMin, xMax; // Costrain the paddle for the screen size
        }
        #region Paddle Variables
        public Boundary boundary;       // Variable that references the class 
        [SerializeField]                // Allows for the variable to be visible in the inspector/IDE from the base/derived class 
        protected float PadSpeed;       // Value of the speed paddle moves at
        protected Rigidbody2D rb2d;     // Reference of the Rigidbody2d IDE Component
        #endregion
        protected new virtual void Start()
        {
            
        }
        protected virtual void Update()
        {
            // Functions
            PaddMovement();
        }

        #region PaddleMovement
        protected virtual void PaddMovement()   // A function created for Paddle Movement
        {
            float xPos = Input.GetAxis("Horizontal");       // xPos holds reference to the player input
            Vector2 movement = new Vector2 (xPos, 0f);      // Movement holds a new vector of the player inputs on the X axis
            rb2d.velocity = movement * PadSpeed;            // Rigidbody2D uses velocity and the movement variable to move with speed

            rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax), -4f);       // rigidbody2D clamps its position within the X axis
        }
        #endregion
    }
    #endregion
}
