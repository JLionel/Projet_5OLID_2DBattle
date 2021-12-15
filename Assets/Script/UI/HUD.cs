using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private FloatVariable timerValue;
    [SerializeField] private FloatVariable cooldownValue;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI cooldownText;

    [Header("Player Count")] 
    [SerializeField] private TextMeshProUGUI playerCountText;
    [SerializeField] [CanBeNull] private PlayerNames playerNames;
    private int _maxPlayerCount;
    private int _currentPlayerCount;

    private void Start()
    {
        if (playerNames != null)
        {
            _maxPlayerCount = playerNames.GetPlayerCount();
        }
        else
        {
            playerCountText.gameObject.SetActive(false);
        }
        
        slider.maxValue = timerValue.Value;
    }

    void Update()
    {
        if (playerNames != null)
        {
            _currentPlayerCount = playerNames.GetPlayerCount();
        }
        
        playerCountText.text = _currentPlayerCount + "/" + _maxPlayerCount;
        
        slider.value = timerValue.Value;

        if (timerValue.Value <= 0.1f)
        {
            StartCoroutine(ShowCooldownCoroutine());
        }
    }

    private IEnumerator ShowCooldownCoroutine()
    {
        var cooldown = cooldownValue.Value;
        var timer = cooldown;

        while (timer >= 0.1f)
        {
            timer -= 0.1f;
            
            if (timer >= 0)
                cooldownText.text = null;
            
            cooldownText.text = timer.ToString("N1");
            yield return new WaitForSeconds(0.1f);
        }

        cooldownText.text = null;
    }
}
