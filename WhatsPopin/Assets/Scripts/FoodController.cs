using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    public GameObject location;
    /// <summary>
    /// To be called from the 'Throwable' 
    /// script's "OnDetachFromHand()' event
    /// </summary>
    public void OnFoodReleased()
    {
        //Set a timer of '5 seconds'.
        //If we don't hit the pins within this time,
        //then we assume the ball has gone astray
        //Reset and spawn a new ball for the next
        //try
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3.0f);

        gameObject.transform.position = location.transform.position;
    }
}
