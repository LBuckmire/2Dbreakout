using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddMve : The_Base
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        PaddMovement();
    }
    protected override void PaddMovement()
    {
        base.PaddMovement();
    }
}