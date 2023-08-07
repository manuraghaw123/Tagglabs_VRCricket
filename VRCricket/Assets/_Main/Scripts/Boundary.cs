using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    [SerializeField]
    bool smallBoundary;
    private void OnTriggerExit(Collider other)
    {
        if (Manager.instance.isBatTouch)
        {
            if (other.CompareTag("Ball"))
            {
                if (smallBoundary)
                {
                  Manager.instance.CalculateOneorTwo();
                }
                else
                {
                  Manager.instance.CalculatefourSix();
                }
            }
        }
    }
}
