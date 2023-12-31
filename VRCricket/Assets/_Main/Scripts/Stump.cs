using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
    [SerializeField]
    Transform[] stumpTransforms;

    [SerializeField]
    Vector3[] initalPos, initalRot;

    void Start()
    {
        for (int i = 0; i < stumpTransforms.Length; i++)
        {
            initalPos[i] = stumpTransforms[i].localPosition;
            initalRot[i] = stumpTransforms[i].localEulerAngles;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Out");
            Out();
        }
            
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }

   public void ResetWicket()
    {
        for (int i = 0; i < stumpTransforms.Length; i++)
        {
            stumpTransforms[i].GetComponent<Rigidbody>().isKinematic = true;
            stumpTransforms[i].localPosition = initalPos[i];
            stumpTransforms[i].localEulerAngles = initalRot[i];
        }
    }

    void Out()
    {
        for (int i = 0; i < stumpTransforms.Length; i++)
        {
            stumpTransforms[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
