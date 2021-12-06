using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private StringVariable menuScene;
    public void OnClickBack()
    {
        SceneManager.LoadScene(menuScene.Value);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
