using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    Rigidbody r;
    public GameObject R_Controller;
    public GameObject L_Controller;

    void Start ()
    {
        r = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        r.MovePosition(R_Controller.transform.position);
        r.MoveRotation(R_Controller.transform.rotation);
    }

   


}
