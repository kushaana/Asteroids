using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    protected float points;
    GameObject hud;
    HUD hudScript;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        hud = GameObject.FindWithTag("HUD");
        hudScript = hud.GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            hudScript.AddPoints(points);
            Destroy(gameObject);
        }
    }
}
