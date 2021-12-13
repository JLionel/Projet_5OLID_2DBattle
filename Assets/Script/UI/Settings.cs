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
    [SerializeField] private TextMeshProUGUI twitchName;
    [SerializeField] private TextMeshProUGUI twitchAuth;
    [SerializeField] private TwitchAcountCredentials twitchCredentials;

    private string VolumeKey = "Volume value";

    private void Start()
    {
        float value = PlayerPrefs.GetFloat(VolumeKey);
        slider.value = value;
    }

    private void Update()
    {
        var value = slider.value;
        
        volumeText.text = value.ToString("N0");
        
        PlayerPrefs.SetFloat(VolumeKey, value);

        twitchCredentials.Username = twitchName.text;
        twitchCredentials.TwitchAcountName = twitchName.text;

        twitchCredentials.OauthPassword = twitchAuth.text;
    }
}
