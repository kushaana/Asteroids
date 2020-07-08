using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBrick : Brick
{
    // Start is called before the first frame update
    void Start()
    {
        points = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
