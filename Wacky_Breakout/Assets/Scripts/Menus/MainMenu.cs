using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene("gameplay");
    }

    public void HelpOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        MenuManager.GoToMenu(Menu.Help);
    }

    public void QuitOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        Application.Quit();
    }
}
