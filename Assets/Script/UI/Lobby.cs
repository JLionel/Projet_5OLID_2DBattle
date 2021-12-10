using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private GameEvent startGame;
    [SerializeField] private StringVariable gameScene;
    public void OnClickStart()
    {
        SceneManager.LoadScene(gameScene.Value);
        startGame.Raise();
        
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
