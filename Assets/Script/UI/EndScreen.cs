using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private StringVariable menuScene;
    public void OnMenuClick()
    {
        SceneManager.LoadScene(menuScene.Value);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
