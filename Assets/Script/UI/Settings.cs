using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private StringVariable menuScene;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI volumeText;
    public void OnClickBack()
    {
        SceneManager.LoadScene(menuScene.Value);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    private void Update()
    {
        var value = slider.value * 100;
        volumeText.text = value.ToString("N0");
    }
}
