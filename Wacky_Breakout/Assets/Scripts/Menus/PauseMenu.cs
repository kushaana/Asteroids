using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void ResumeOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        Camera.main.GetComponent<PauseGame>().paused = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void QuitOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menu.Main);
    }
}
