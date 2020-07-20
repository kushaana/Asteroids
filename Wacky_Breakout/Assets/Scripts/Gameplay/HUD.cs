using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text Balls;
    [SerializeField]
    Text Score;

    float balls=0;
    public float score=0;
    LastBallLost lastBallLostEvent;
    public bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        balls = ConfigurationUtils.BallsPerGame;
        Balls.text = "Balls left: " + balls.ToString();
        EventManager.AddPointsEventListener(AddPoints);
        EventManager.AddReduceBallsEventListener(BallLeft);

        lastBallLostEvent = new LastBallLost();
        EventManager.AddLastBallLostEventInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (balls == 0 && !gameover)
        {
            lastBallLostEvent.Invoke();
            gameover = true;
        }
        if (GameObject.FindGameObjectsWithTag("Brick").Length == 0 && !gameover)
        {
            lastBallLostEvent.Invoke();
            gameover = true;
        }
    }

    void AddPoints(float points)
    {
        score += points;
        Score.text = "Score: " + score.ToString();
    }

    void BallLeft()
    {
        balls--;
        Balls.text = "Balls left: " + balls.ToString();
    }

    public void AddLastBallLostEventListener(UnityAction lastBallLostHandler)
    {
        lastBallLostEvent.AddListener(lastBallLostHandler);
    }
}
