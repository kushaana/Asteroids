using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        GameObject asteroid1 = Instantiate(prefabAsteroid, new Vector3(0, ScreenUtils.ScreenBottom, -Camera.main.transform.position.z), Quaternion.identity);
        asteroid1.GetComponent<Asteroid>().Initialize(Direction.Up);
        GameObject asteroid2 = Instantiate(prefabAsteroid, new Vector3(0, ScreenUtils.ScreenTop, -Camera.main.transform.position.z), Quaternion.identity);
        asteroid2.GetComponent<Asteroid>().Initialize(Direction.Down);
        GameObject asteroid3 = Instantiate(prefabAsteroid, new Vector3(ScreenUtils.ScreenLeft, 0, -Camera.main.transform.position.z), Quaternion.identity);
        asteroid3.GetComponent<Asteroid>().Initialize(Direction.Right);
        GameObject asteroid4 = Instantiate(prefabAsteroid, new Vector3(ScreenUtils.ScreenRight, 0, -Camera.main.transform.position.z), Quaternion.identity);
        asteroid4.GetComponent<Asteroid>().Initialize(Direction.Left);
    }

    // Update is called once per frame
}
