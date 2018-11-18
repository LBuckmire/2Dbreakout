using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : The_Base
{
    public float timeDestroy = 1f;

    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, timeDestroy);
	}
	
}
