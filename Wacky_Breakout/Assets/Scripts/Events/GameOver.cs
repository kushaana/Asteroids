using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddLastBallLostEventListener(DisplayGameOver);
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void DisplayGameOver()
    {
        GameObject.Instantiate(Resources.Load("GameOver"));
        GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>().text = "Score: " + hud.score.ToString();
    }
}
