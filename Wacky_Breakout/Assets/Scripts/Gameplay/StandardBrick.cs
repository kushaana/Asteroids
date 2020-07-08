using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBrick : Brick
{
    [SerializeField]
    Sprite[] bricksprite = new Sprite[4];
    // Start is called before the first frame update
    void Start()
    {
        points = ConfigurationUtils.StdBlockPoints;
        SpriteRenderer randsprite = GetComponent<SpriteRenderer>();
        randsprite.sprite = bricksprite[Random.Range(0, 4)];
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
