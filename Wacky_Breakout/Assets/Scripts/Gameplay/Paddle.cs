using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Paddle
public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    float halfColliderWidth;
    float halfColliderHeight;
    const float BounceAngleHalfRange = (float)Math.PI / 3;
    Timer freezeTimer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y / 2;

        freezeTimer = gameObject.AddComponent<Timer>();
        EventManager.AddFreezeListener((float freezeDuration) => { freezeTimer.Duration = freezeDuration; freezeTimer.Run(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float horizontal = 0;
        if (!freezeTimer.Running)
            horizontal = Input.GetAxis("Horizontal");
        Vector3 deltapos = Vector3.right * horizontal * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
        float adjusted_x = CalculateClamedX(transform.position.x + deltapos.x);
        rb2d.MovePosition(new Vector3(adjusted_x, transform.position.y, transform.position.z));
    }

    float CalculateClamedX(float x)
    {
        if(x - halfColliderWidth < ScreenUtils.ScreenLeft || x + halfColliderWidth > ScreenUtils.ScreenRight)
            return transform.position.x;
        else 
            return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        AudioManager.Play(AudioClipName.HitPaddle);
        if (coll.gameObject.CompareTag("Ball") && IsTop(coll))
        {           
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool IsTop(Collision2D coll)
    {
        float collisionY = coll.GetContact(0).point.y;
        float topY = transform.position.y + halfColliderHeight;
        
        if (collisionY <= topY + 0.05 && collisionY >= topY - 0.05)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
