using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float killTime = 1f;
    Timer deathTimer;
    public void ApplyForce(Vector2 forceDirection)
    {
        const float forceMagnitude = 7f;
        GetComponent<Rigidbody2D>().AddForce(forceMagnitude * forceDirection, ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = killTime;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (!deathTimer.Running) Destroy(gameObject);
    }
}
