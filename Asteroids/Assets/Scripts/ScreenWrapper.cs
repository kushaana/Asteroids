using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float rad;
    // Start is called before the first frame update
    void Start()
    {
        rad = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    void OnBecameInvisible()
    {
        Vector3 pos = gameObject.transform.position;
        if (pos.x > ScreenUtils.ScreenRight)
        {
            pos.x = ScreenUtils.ScreenLeft ;
        }
        if (pos.x < ScreenUtils.ScreenLeft)
        {
            pos.x = ScreenUtils.ScreenRight ;
        }
        if (pos.y > ScreenUtils.ScreenTop)
        {
            pos.y = ScreenUtils.ScreenBottom ;
        }
        if (pos.y < ScreenUtils.ScreenBottom)
        {
            pos.y = ScreenUtils.ScreenTop ;
        }
        gameObject.transform.position = pos;
    }
}
