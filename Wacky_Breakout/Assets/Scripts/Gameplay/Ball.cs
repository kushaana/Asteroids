using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ball
public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        double angle = Math.PI / 180 * 270;
        float magnitude = ConfigurationUtils.BallImpulseForce;
        Vector2 force = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * magnitude;

        GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<Rigidbody2D>().velocity.magnitude;
    }
}
