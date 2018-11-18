using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMve : The_Base
{

	// Use this for initialization
	protected override void Awake ()
    {
        base.Awake();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        BallMovement();
    }
    protected override void BallMovement()
    {
        base.BallMovement();
    }
}
