using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private FloatVariable timerValue;
    [SerializeField] private FloatVariable cooldownValue;
    
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI cooldownText;

    void Update()
    {
        slider.value = timerValue.Value;

        if (timerValue.Value <= 0.1f)
        {
            StartCoroutine(ShowCooldownCoroutine());
        }
    }

    private IEnumerator ShowCooldownCoroutine()
    {
        Debug.Log("Started Coroutine");
        var cooldown = cooldownValue.Value * 3;
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
