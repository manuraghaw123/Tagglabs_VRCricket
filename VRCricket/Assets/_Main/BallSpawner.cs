using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject Ball;
    void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);
        Instantiate(Ball, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        Debug.Log("Balled Spawned");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnBall();
        }
    }
}
