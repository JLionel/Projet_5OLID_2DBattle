using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameEvent enterLobby;
    [SerializeField] private StringVariable lobbyScene;
    [SerializeField] private StringVariable settingsScene;
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(lobbyScene.Value);
        enterLobby.Raise();
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
