using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBrick : Brick
{
    [SerializeField]
    Sprite[] sprites = new Sprite[2];
    PickupEffect effect;
    public FreezerEffectActivated freezerEffect;
    public SpeedUpEventActivated speedUpEvent;

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
                        freezerEffect = new FreezerEffectActivated();
                        GetComponent<SpriteRenderer>().sprite = sprites[0];
                        EventManager.AddFreezeInvoker(this);
                        break;
                    }
                case (PickupEffect.Speedup):
                    {
                        speedUpEvent = new SpeedUpEventActivated();
                        GetComponent<SpriteRenderer>().sprite = sprites[1];                        
                        EventManager.AddSpeedUpEventInvoker(this);
                        break;
                    }
            }
        }
    }
    // Start is called before the first frame update
    protected override void Start()
    {
        int pickuptype = Random.Range(0, 2);
        if (pickuptype == 0) Effect = PickupEffect.Freezer;
        else Effect = PickupEffect.Speedup;
        points = ConfigurationUtils.PickupBlockPoints;
        base.Start();
    }

    // Update is called once per frame
    protected override void OnCollisionEnter2D(Collision2D other)
    { 
        if (Effect == PickupEffect.Freezer)
        {
            freezerEffect.Invoke(ConfigurationUtils.FreezeTime);
        }
        if (Effect == PickupEffect.Speedup)
        {
            speedUpEvent.Invoke(ConfigurationUtils.SpeedUpTime, ConfigurationUtils.SpeedUpFactor);
        }
        base.OnCollisionEnter2D(other);
    }

    public void AddFreezeEventListener(UnityAction<float> freezeEventHandler)
    {
        freezerEffect.AddListener(freezeEventHandler);
    }

    public void AddSpeedUpEventListener(UnityAction<float, float> speedUpEventHandler)
    {
        speedUpEvent.AddListener(speedUpEventHandler);
    }
}
