using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Update is called once per frame
    public bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            MenuManager.GoToMenu(Menu.Pause);
        }
    }
}
