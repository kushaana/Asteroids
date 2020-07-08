using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text Balls;
    [SerializeField]
    Text Score;

    static float balls=0;
    static float score=0;
    // Start is called before the first frame update
    void Start()
    {
        balls = ConfigurationUtils.BallsPerGame;
        Balls.text = "Balls left: " + balls.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(float points)
    {
        score += points;
        Score.text = "Score: " + score.ToString();
    }

    public void BallLeft()
    {
        balls--;
        Balls.text = "Balls left: " + balls.ToString();
    }
}
