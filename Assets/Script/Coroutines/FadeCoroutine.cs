using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeCoroutine : MonoBehaviour
{
    [SerializeField] [Range(0, 1)]private float fadeSpeed;
    [SerializeField] private Image fadeImage;
    [SerializeField] private BoolVariable fadeOutFinished;

    private IEnumerator Start()
    {
        fadeOutFinished.Value = false;
        yield return StartCoroutine(FadeOut());
        fadeOutFinished.Value = true;
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("FadeIn Start");

        while (fadeImage.color.a > 0)
        {
            fadeImage.color -= new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        
        Debug.Log("FadeIn End");
    }
    private IEnumerator FadeOut()
    {
        Debug.Log("FadeOut Start");

        while (fadeImage.color.a < 1)
        {
            fadeImage.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return null;
        }
        
        Debug.Log("FadeOut End");
    }
}
