using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayOnClick()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void HelpOnClick()
    {
        MenuManager.GoToMenu(Menu.Help);
    }

    public void QuitOnClick()
    {
        Application.Quit();
    }
}
