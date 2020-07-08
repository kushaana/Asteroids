using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    float minSpawnTime;
    float maxSpawnTime;
    float randomSpawnTime;
    Timer randomspawner;
    Vector2 ballDownLeftCorner;
    Vector2 ballUpRightCorner;
    bool retrySpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempball = Instantiate(ballPrefab);
        Vector3 scaleOfBall = tempball.transform.lossyScale;
        float ballHalfWidth = scaleOfBall.x / 2.0f;
        float ballHalfHeight = scaleOfBall.y / 2.0f;
        ballDownLeftCorner = new Vector2(tempball.transform.position.x - ballHalfWidth, tempball.transform.position.y - ballHalfHeight);
        ballUpRightCorner = new Vector2(tempball.transform.position.x + ballHalfWidth, tempball.transform.position.y + ballHalfHeight);
        Destroy(tempball);
        Initialize();

        minSpawnTime = ConfigurationUtils.MinRandomSpawnTime;
        maxSpawnTime = ConfigurationUtils.MaxRandomSpawnTime;
        randomspawner = gameObject.AddComponent<Timer>();
        RunRandomSpawner(randomspawner);

    }

    // Update is called once per frame
    void Update()
    {
        if (randomspawner.Finished || retrySpawn)
        {
            Initialize();
            RunRandomSpawner(randomspawner);
        }
        
    }

    //Spawn new ball
    public void Initialize()
    {
        if (Physics2D.OverlapArea(ballDownLeftCorner, ballUpRightCorner) == null)
        {
            Instantiate(ballPrefab);
            retrySpawn = false;
        }
        else
        {
            retrySpawn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.FindWithTag("HUD").GetComponent<HUD>().BallLeft();
        Destroy(collision.gameObject);
        Initialize();
    }

    void RunRandomSpawner(Timer randomspawner)
    {
        randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        randomspawner.Duration = randomSpawnTime;
        randomspawner.Run();
    }
}
