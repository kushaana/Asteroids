using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        sp.sprite = asteroid[Random.Range(0, 3)];

    }

  
}
