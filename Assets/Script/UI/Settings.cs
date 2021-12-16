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
    [SerializeField] private TMP_InputField twitchName;
    [SerializeField] private TMP_InputField twitchAuth;
    [SerializeField] private TwitchAcountCredentials twitchCredentials;

    [SerializeField] private StringVariable volumeKey;

    private void Start()
    {
        float value = PlayerPrefs.GetFloat(volumeKey.Value);
        slider.value = value;
    }

    private void Update()
    {
        var value = slider.value;
        PlayerPrefs.SetFloat(volumeKey.Value, slider.value);

        volumeText.text = value.ToString("N0");
    }

    public void SaveSettings()
    {
        twitchCredentials.Username = twitchName.text.ToLower();
        twitchCredentials.TwitchAccountName = twitchName.text.ToLower();

        twitchCredentials.OauthPassword = twitchAuth.text;
    }
}
