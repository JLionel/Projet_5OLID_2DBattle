using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject quitButton;

    private void OnClickPlayButton()
    {
        
    }

    private void OnClickSettingsButton()
    {
        
    }

    private void OnClickQuitButton()
    {
        Application.Quit();
    }
}
