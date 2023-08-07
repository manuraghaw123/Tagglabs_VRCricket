using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGroundTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
            Debug.Log("Ground Touch");

    }
}
