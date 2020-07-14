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
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void QuitOnClick()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menu.Main);
    }
}
