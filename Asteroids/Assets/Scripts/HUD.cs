using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text score;
    bool running;

    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "0";
        running = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (running) {
            time += Time.deltaTime;
            int secs = (int)time;
            score.text = secs.ToString();
        }
    }

    public void StopGameTimer()
    {
        running = false;
        score.text += "\nGame Over!";
    }
}
