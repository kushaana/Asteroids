using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite[] asteroid = new Sprite[3]; 

    public void Initialize(Direction direction)
    {
        const float MinImpulseForce = 1.5f;
        const float MaxImpulseForce = 2.5f;
        float angle = Random.Range(0, 50 * Mathf.Deg2Rad);
        if (direction == Direction.Up) angle += 65 * Mathf.Deg2Rad;
        if (direction == Direction.Down) angle += 245 * Mathf.Deg2Rad;
        if (direction == Direction.Right) angle += 335 * Mathf.Deg2Rad;
        if (direction == Direction.Left) angle += 155 * Mathf.Deg2Rad;
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    public void Initialize(float angle)
    {
        const float MinImpulseForce = 1.5f;
        const float MaxImpulseForce = 2.5f;
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = asteroid[UnityEngine.Random.Range(0, 3)];

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Vector3 localscale = transform.localScale;
            if(localscale.x < 0.5)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else
            {
                localscale.x /= 2;
                localscale.y /= 2;
                transform.localScale = localscale;

                GameObject copy1 = Instantiate(gameObject);
                GameObject copy2 = Instantiate(gameObject);
                copy1.GetComponent<Asteroid>().Initialize(Random.Range(0, 2 * (float)Math.PI));
                copy2.GetComponent<Asteroid>().Initialize(Random.Range(0, 2 * (float)Math.PI));
                Destroy(gameObject);
                Destroy(collision.gameObject);
            } 
        }
    }
}
