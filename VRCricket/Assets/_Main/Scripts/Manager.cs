using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    TextMeshPro BallsText, ScoreText, ResultText, overText;

    int totalBalls;

    public int totalScore;
    int oneOrtwo;
    bool isOneOrTwoCalculated;
    int ballSpawned;
    int overs;
    float resetTimer = 3;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    TextMeshPro nameText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Overs"))
        {
            totalBalls = PlayerPrefs.GetInt("Overs") * 6;
          
        }
        else
        {
            totalBalls = 18;
        }

        if (PlayerPrefs.HasKey("Name"))
        {
            nameText.text = PlayerPrefs.GetString("Name");
        }
        else
        {
            nameText.text = "Player";
        }

        BallsText.text = "Balls Remaining : " + totalBalls.ToString();
        overText.text = "OVERS : " + overs.ToString();
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
        ballSpawned++;
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
        if (ballSpawned % 6 == 0)
        {
            overs++;
            overText.text = "OVERS : " + overs.ToString();
        }
        totalBalls--;
        BallsText.text = "Balls Remaining : " + totalBalls.ToString();

        if (totalBalls == 0)
        {
            ShowResult("Thank You!");
        }
        else
        {

            isBatTouch = false;
            isGroundTouch = false;
            isOneOrTwoCalculated = false;
            bowlingTrigerObject.SetActive(true);
            wicketStump.ResetWicket();
            ShowScore();
            ResultText.text = " ";

        }


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
        if (totalScore < 10)
        {
            ScoreText.text = "0"+totalScore.ToString();
        }
        else
        {
            ScoreText.text = totalScore.ToString();
        }
       
    }

    void ShowResult(string resultText)
    {
        ResultText.text = resultText;
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            resetTimer -= Time.deltaTime;

            if (resetTimer < 0)
            {
                SceneManager.LoadScene(0);
            }

        }

        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            resetTimer = 3;
        }
    }





}
