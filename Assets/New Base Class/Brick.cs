using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]   // Allows for the variable to be visible in the inspector/IDE from the base/derived class
    public int score; // Sets the score value of the brick, which goes to the total score

    // A function for declaring an object has collided with another
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);    // Destorys the brick

        GM.sGM.SendMessage("Score_Points", score);  // Sends the Brick.score value to the Score_Points void in the Game Manager
    }

}
