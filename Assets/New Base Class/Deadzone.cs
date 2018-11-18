using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : The_Base
{
    void OnTriggerEnter2D(Collider2D DZtrig)
    {
        GM.instance.LoseLives();
    }
}
