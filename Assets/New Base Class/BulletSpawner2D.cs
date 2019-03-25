using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner2D : MonoBehaviour
{
    //Public Variables
    public GameObject SpawnerBulletShoot;   //The bullet the spawner will shoot
    public Transform ShootingPoint;        // Sets/knows the position, rotation and scale of the point where the bullet is shot from
    public bool InfiniteBulletSpawn = true;    //Trigger if you want the spawner to shoot infinitely
    public bool BulletDestroy = false;  //Destroy the bullet after you have finished with it
    public int SpawnTotal = 10; //The number of bullets you want to set the spawner to shoot
    public float SpawnerDelay = 1;  //Set the cooldown/delay time for the spawner

    private float NextSpawnTime;    //When the spawner will spawn the next bullet



	// Use this for initialization
	void Start ()
    {
        // The next spawn for the bullets = spawning based on the float set and run based on the time in seconds since the start of the game
        NextSpawnTime = SpawnerDelay + Time.time;   

        // The point the bullet shoots from = where the gameobject tagged "Shooting_Point" is and its tranform is obtained and set
        ShootingPoint = GameObject.Find("Shooting_Point").GetComponent<Transform>(); 
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Sets the condition that if the time since the start of the game is greater than the next spawn time
        //and the InfiniteBulletSpawn is active and/or the SpawnTotal is greater than 0, the statement is invoked
        if (Time.time > NextSpawnTime && (InfiniteBulletSpawn || SpawnTotal > 0))
        {
            // A bullet is instantiated at the tranform for this object and set to face up in regard to the attatched gameobject's direction
            Instantiate(SpawnerBulletShoot, transform.position + transform.TransformDirection(Vector3.up), transform.rotation);

            // The next spawne time is based on the time since the start of the game and the delay set on the spawner
            NextSpawnTime = Time.time + SpawnerDelay; 
            
            // Sets the condition that if the InfiniteBulletSpawn is false the the SpawnTotal will go down in value
            if (!InfiniteBulletSpawn) SpawnTotal--;
        }
        // Sets the condition that if the bullet isn't destoryed and the SpawnTotal is less than 1 then destroy the bullet
        if (BulletDestroy && SpawnTotal < 1) Destroy(gameObject);
	}
}
