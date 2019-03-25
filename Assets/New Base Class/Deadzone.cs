using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The Script for the "Deadzone" inheriting the information from The_Base
public class Deadzone : The_Base
{
    public void OnTriggerEnter2D(Collider2D DZcoll) // A function for declaring an object has entered a trigger object area
    {
        if (DZcoll.gameObject.tag == "Ball") // If the object tagged "Ball" enters with the Deadzone then activate the statement actions
        {
            Destroy(DZcoll.gameObject); // The game object which collides with the Dead Zone will be destoryed
            GM.gameOver = false; // The gameOver boolean in the Game Manager is set to false
            GM.startGame = false; // The startGame boolean in the Game Manager is set to true  
            SceneManager.LoadSceneAsync("GameOver"); // The game transitions to the scene named "GameOver" 
        }
        
    }
}
