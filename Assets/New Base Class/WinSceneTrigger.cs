using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneTrigger : MonoBehaviour
{
    // a public variable - a variable which can be accessed in the IDE/inspector
    public string WinScene; // Declaring a string variable which can be used in the IDE to enter a string of letters and numbers 

    // This is a trigger that will activate when and object collides with it
    void OnTriggerEnter2D(Collider2D WinTrig)   
    {
        // Set a condition that if that the trigger will be activated if the GameObject tagged "Ball" collides with it
        if (WinTrig.gameObject.tag == "Ball")
        {
            // This will command the scene manager to load the scene with the string name that has been entered in to the Inspector
            SceneManager.LoadScene(WinScene);    
        }
    }
}
