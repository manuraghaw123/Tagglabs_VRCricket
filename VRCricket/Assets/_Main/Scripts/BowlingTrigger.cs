using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bat"))
            Manager.instance.BowlingTrigger();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
            Manager.instance.BowlingTrigger();

    }
}
