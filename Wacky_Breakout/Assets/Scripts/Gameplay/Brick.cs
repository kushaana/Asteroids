using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    protected float points;
    public AddPoints addPointsEvent;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        addPointsEvent = new AddPoints();
        EventManager.AddPointsEventInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        AudioManager.Play(AudioClipName.HitBrick);
        if (other.gameObject.CompareTag("Ball"))
        {
            addPointsEvent.Invoke(points);
            Destroy(gameObject);
        }
    }

    public void AddPointsEventListener(UnityAction<float> addPointsHandler)
    {
        addPointsEvent.AddListener(addPointsHandler);
    }
}
