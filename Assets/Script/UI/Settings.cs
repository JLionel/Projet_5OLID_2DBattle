using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI volumeText;
    private void Update()
    {
        var value = slider.value * 100;
        volumeText.text = value.ToString("N0");
    }
}
