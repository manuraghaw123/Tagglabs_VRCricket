using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public bool isBatTouch, isGroundTouch;
    [SerializeField]
    AudioSource hitBatSound, clapSound;

    [SerializeField]
    TextMeshPro BallsText, ScoreText, ResultText;

    int totalBalls;

    public int totalScore;
    int oneOrtwo;
    bool isOneOrTwoCalculated;

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
        totalBalls++;
        BallsText.text = totalBalls.ToString();
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
        isBatTouch = false;
        isGroundTouch = false;
        isOneOrTwoCalculated = false;
        bowlingTrigerObject.SetActive(true);
        wicketStump.ResetWicket();
        ShowScore();
        ResultText.text = " ";
    }

    public void HitBat()
    {
        isBatTouch = true;
        hitBatSound.Play();
    }

    public void CalculateOneorTwo()
    {
        if (!isOneOrTwoCalculated)
        {
            if (isGroundTouch)
            {
                oneOrtwo = 1;
            }
            else
            {
                oneOrtwo = 2;
            }

            totalScore += oneOrtwo;
            isOneOrTwoCalculated = true;
            Invoke("ShowScore", 3f);
        }
    }

    public void CalculatefourSix()
    {
        if (isOneOrTwoCalculated)
        {
            totalScore -= oneOrtwo;
        }

        if (isGroundTouch)
        {
            totalScore += 4;
            ShowResult("4");
        }
        else
        {
            totalScore += 6;
            ShowResult("6");
        }
        clapSound.Play();
        ShowScore();
    }

    void ShowScore()
    {
        ScoreText.text = totalScore.ToString();
    }

    void ShowResult(string resultText)
    {
        ResultText.text = resultText;
    }



}
