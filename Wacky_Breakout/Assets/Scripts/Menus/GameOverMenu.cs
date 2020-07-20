using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Play(AudioClipName.GameOver);
        Time.timeScale = 0;
    }

    public void QuitOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menu.Main);
    }
}
