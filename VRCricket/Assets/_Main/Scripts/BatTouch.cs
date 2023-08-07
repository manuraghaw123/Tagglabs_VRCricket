using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            Debug.Log("Hit");
            Manager.instance.HitBat();
          
        }
    }
}
