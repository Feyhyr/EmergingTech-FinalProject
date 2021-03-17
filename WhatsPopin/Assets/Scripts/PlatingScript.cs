using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatingScript : MonoBehaviour
{

    public bool isOnPlate = false;

    private void Update()
    {
       /* foreach (GameObject ingrediant in myFoods)
        {
            ingrediant.transform.SetParent(this.transform);
        }
       */

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            isOnPlate = true;
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            isOnPlate = false;
            collision.transform.parent = null;
        }
    }
    

}
