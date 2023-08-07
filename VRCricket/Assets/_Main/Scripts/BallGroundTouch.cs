using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGroundTouch : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if (Manager.instance.isBatTouch)
            {
                Manager.instance.isGroundTouch = true;
                Debug.Log("GroumdTouch");
            }
        }
    }

    
}
