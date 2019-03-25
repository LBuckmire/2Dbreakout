using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    // Public Variables

    public float BulletSpeed = 5;   // Declaring the Speed the bullet will travel at
    public float BulletRange = 10;  // Declaring the Range the bullet can travel to
    public float BulletDamage = 10; // Declaring the Damage the bullet sends
    public string DeathScene;   // Making a string space in the IDE

    private Rigidbody2D BulletRB; // Declaring a variable which will be assigned as the rigidbody


    // Use this for initialization
    void Start ()
    {
        // Called the Rigidbody 2D for the bullet
        BulletRB = GetComponent<Rigidbody2D>();

        // Setting the bullets shooting direction using 2D vectors and points
        Vector2 BulletDirection = transform.TransformDirection(Vector2.up);

        // Sets the bullets velocity based on the direction and speed
        BulletRB.velocity = BulletDirection * BulletSpeed;

        // Destroys the bullet based on the set BulletRange divided by the absolut value of the BulletSpeed
        Destroy(gameObject, BulletRange / Mathf.Abs(BulletSpeed));
    }

    // A function for declaring an object has entered a trigger object area
    void OnTriggerEnter2D(Collider2D BulletCollision)
    {
        // Sets the condition that if the bullet hits the gameobject tagged paddle, then invoke the actions in the statement
        if (BulletCollision.tag == "Paddle")
        {
            Destroy(gameObject); // Destroy the bullet
            GM.gameOver = false; // The gameOver boolean in the Game Manager is set to false
            GM.startGame = false; // The startGame boolean in the Game Manager is set to true  
            SceneManager.LoadSceneAsync(DeathScene); // The game transitions to the scene with the name entered in to the string in the IDE
        }

    }//-----
}
