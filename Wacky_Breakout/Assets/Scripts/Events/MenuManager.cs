using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(Menu menu)
    {
        switch (menu)
        {
            case (Menu.Main):
                {
                    SceneManager.LoadScene("main");
                    break;
                }
            case (Menu.Help):
                {
                    GameObject mainMenuCanvas = GameObject.FindGameObjectWithTag("MainMenuCanvas");
                    mainMenuCanvas.SetActive(false);
                    Object.Instantiate(Resources.Load("HelpMenu"));
                    break;
                }
            case (Menu.Pause):
                {
                    Object.Instantiate(Resources.Load("PauseMenu"));
                    break;
                }
        }
    }
}
