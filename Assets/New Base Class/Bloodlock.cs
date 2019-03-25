///<summary>
/// This code is based on and accredited to David Dorrington, UEL Games, 2017
///</summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodlock : MonoBehaviour
{
    public GameObject[] TriggerObjects; // An array used for GameObjects (In this case Bricks) 
    public GameObject ActivatedObject;  // The GameObject that will appear once the blood lock is opened
    public bool Activated;  // The boolean which states whether the ActivatedObject is active or not

	// Use this for initialization
	void Start ()
    {
        // States that if the Activated boolean is true then the ActivatedObject will be false
        if (Activated) ActivatedObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        // Number of objects at start the need to be destoryed to open the bloodlock
        int ObjectStartTotal = TriggerObjects.Length;

        // Sets it so it constantly checks through the TriggerObjects
        foreach (GameObject Gobject in TriggerObjects)
        {
            // If the gameobject is gone from the scene the take 1 away from the object total
            if (!Gobject) ObjectStartTotal--; 
        }

        // Sets the condition that if the number of TriggerObjects left in the scene is less than 1, then the statments are activated
        if (ObjectStartTotal < 1)
        {
            // States that if the Activated boolean is true then, the statement is activated
            if (Activated)  
                ActivatedObject.SetActive(true);    // Turns on the activated object

            // States that if the Activated boolen is false, then the statement is activated
            else
                ActivatedObject.SetActive(false);   // Turns off the activated object
        }
	}

}
