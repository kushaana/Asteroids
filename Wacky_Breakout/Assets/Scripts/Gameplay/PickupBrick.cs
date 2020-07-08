using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBrick : Brick
{
    [SerializeField]
    Sprite[] sprites = new Sprite[2];
    PickupEffect effect;

    public PickupEffect Effect
    {
        get { return effect; }
        set
        {
            effect = value;
            switch (value)
            {
                case (PickupEffect.Freezer):
                    {
                        GetComponent<SpriteRenderer>().sprite = sprites[0];
                        break;
                    }
                case (PickupEffect.Speedup):
                    {
                        GetComponent<SpriteRenderer>().sprite = sprites[1];
                        break;
                    }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        points = ConfigurationUtils.PickupBlockPoints;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
