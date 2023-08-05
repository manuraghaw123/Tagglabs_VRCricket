using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    BallSpawner ballSpawner;
    [SerializeField]
    Animator bowlerAnimator;

    public void DoBowling()
    {
        bowlerAnimator.ResetTrigger("idle");
        bowlerAnimator.SetTrigger("bowling");
        Invoke("SpawnBall", 1.2f);
    }

    void SpawnBall()
    {
        ballSpawner.SpawnBall();
        Invoke("BowlerIdle", 1f);
    }

    void BowlerIdle()
    {
        bowlerAnimator.ResetTrigger("bowling");
        bowlerAnimator.SetTrigger("idle");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            DoBowling();
    }
}
