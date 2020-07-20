using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackOnClick()
    {
        AudioManager.Play(AudioClipName.Click);
        Destroy(GameObject.FindGameObjectWithTag("HelpMenuCanvas"));
        MenuManager.GoToMenu(Menu.Main);
    }

}
