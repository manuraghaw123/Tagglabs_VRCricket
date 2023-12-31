﻿using UnityEngine;

public class Throw : MonoBehaviour
{
    public int MinThrust;
    public int MaxThrust;
    Rigidbody rb;
    int i;
    public float BallMass = 1.0f;
    void Start()
    {
        Invoke("DestroyBall", 6);
        i = Random.Range(MinThrust, MaxThrust);
        Debug.Log(i);
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * i, ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Bat")
        {
            Debug.Log("HITBAT");
            Manager.instance.HitBat();
        }
    }

   
    void DestroyBall()
    {
       Destroy(this.gameObject);
    }
}