using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    [SerializeField]
    BallSpawner ballSpawner;
    [SerializeField]
    Animator bowlerAnimator;
    [SerializeField]
    float bowlingTriggertime;
    [SerializeField]
    GameObject bowlingTrigerObject;

    [SerializeField]
    Stump wicketStump;

    private void Awake()
    {
        instance = this;
    }

     void DoBowling()
    {
        bowlerAnimator.ResetTrigger("idle");
        bowlerAnimator.SetTrigger("bowling");
        Invoke("SpawnBall", 1.2f);
       
    }

    void SpawnBall()
    {
        ballSpawner.SpawnBall();
        Invoke("BowlerIdle", 1f);
        Invoke("EnableBowlingTrigger", bowlingTriggertime);
    }

    void BowlerIdle()
    {
        bowlerAnimator.ResetTrigger("bowling");
        bowlerAnimator.SetTrigger("idle");
    }

    public void BowlingTrigger()
    {
        bowlingTrigerObject.SetActive(false);
        DoBowling();
    }

    void EnableBowlingTrigger()
    {
        bowlingTrigerObject.SetActive(true);
        wicketStump.ResetWicket();
    }

   
}
