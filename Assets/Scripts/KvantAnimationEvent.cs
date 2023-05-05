using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kvant;

public class KvantAnimationEvent : MonoBehaviour
{
    public Spray spray; 

    public void AdjustThrottle(float duration)
    {

        Debug.Log("AdjustThrottle : " + duration);
        while (duration >0)
        {
            spray.throttle = 1;
            duration -= Time.deltaTime; 
        }
        spray.throttle = 0;
    }

    // This C# function can be called by an Animation Event
    public void PrintFloat(float theValue)
    {
        Debug.Log("PrintFloat is called with a value of " + theValue);
    }

}
