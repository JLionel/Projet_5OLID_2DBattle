using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{
    [SerializeField] private StringVariable gameScene;
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene.Value);
        
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
