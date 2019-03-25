using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMove2D : MonoBehaviour
{
    public float MvmntSpeed = 2f;   // A float used to set the movement of the spawner
    public Vector2 MveEndPos;   // A Vector2 position used to set the end position of the spawner movement

    private Vector2 MveStartPos;    // A Vector2 poisition which denotes the start position of the spawner movement
    private float VectoryMvePath;   // A float used to set the length of the path
    private float TimeStart;    // A float used to set the time that the path takes to start
    private bool right = true;  // A boolean used to detect whether the spawner is moving right or not

	// Use this for initialization
	void Start ()
    {
        MveStartPos = transform.position;   // Variable always equals to the gameObjects transform (Where they are)

        // This sets the lenght of the path so it will equal the set Vector2 Distance (Which is from the start position to the end position)
        VectoryMvePath = Vector2.Distance(MveStartPos, MveEndPos); 
        TimeStart = Time.time;  // The variable is set to the start of the movement of the spawner from the start of the frame
	}
	
	// Update is called once per frame
	void Update ()
    {
        // The variable is equal to the time from the start of the frame minus the start time, divided by the speed. Represented with a float
        float TravelDist = (Time.time - TimeStart) * MvmntSpeed; 
        // The is variable is equal to the distance travelled divided by the length of the path. Represented with a float
        float MveRight = TravelDist / VectoryMvePath;

        // Setting this condition, that if the object is moving right, then the actions below will happen  
        if (right)
        {
            // The position of this gameobject equals its going from its start position and moving towards the end position at a set speed
            transform.position = Vector2.Lerp(MveStartPos, MveEndPos, MveRight);
            // Sets a condition saying if the distance between the gameobject and the end position is less than 0.1 then preform the actions in the statement
            if(Vector2.Distance(transform.position, MveEndPos) < 0.1f)
            {
                right = false;  // The object is no longer moving right/forward
                TimeStart = Time.time;  // That the time starts again from the begining of this frame
            }
        }
        // Setting a condition if the original condition is not met
        else  
        {
            // The position of this gameobject equals its going from its end position and moving towards the start position at a set speed
            transform.position = Vector2.Lerp(MveEndPos, MveStartPos, MveRight);
            // Sets a condition saying if the distance between the gameobject and the start position is less than 0.1 then preform the actions in the statement
            if (Vector2.Distance(transform.position, MveStartPos) < 0.1f)
            {
                right = true;   // The object is moving right/forward
                TimeStart = Time.time;  // That the time starts again from the begining of this frame
            }
        }
    }
}
