using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ball
public class Ball : MonoBehaviour
{
    Timer timer;
    Timer spawntimer;
    bool moving;
    bool speedrestored;
    Timer speedUpTimer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifeTime;
        timer.Run();

        spawntimer = gameObject.AddComponent<Timer>();
        spawntimer.Duration = 1;
        spawntimer.Run();
        moving = false;

        speedUpTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEventListener(speedUp);
        speedrestored = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().Initialize();
            Destroy(gameObject);
        }

        if(spawntimer.Finished && !moving)
        {
            double angle = Math.PI / 180 * 270;
            float magnitude = ConfigurationUtils.BallImpulseForce;
            Vector2 force = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * magnitude;

            GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
            moving = true;

        }

        if(speedUpTimer.Finished && !speedrestored)
        {
            GetComponent<Rigidbody2D>().velocity /= ConfigurationUtils.SpeedUpFactor;
            speedrestored = true;
        }

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(speedrestored)
        rigidbody.velocity = 4 * (rigidbody.velocity.normalized);
        
    }

    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    public void speedUp(float speedUpDuration, float speedUpFactor)
    {
        if (!speedUpTimer.Running)
        {
            GetComponent<Rigidbody2D>().velocity *= speedUpFactor;
            speedUpTimer.Duration = speedUpDuration;
            speedUpTimer.Run();
            speedrestored = false;
        }
    }
}
