using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private StringVariable lobbyScene;
    [SerializeField] private StringVariable settingsScene;
    public void LoadLobbyScene()
    {
        SceneManager.LoadScene(lobbyScene.Value);
    }

    public void OnClickSettingsButton()
    {
        SceneManager.LoadScene(settingsScene.Value);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}
