using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private StringVariable volumeKey;
    private AudioSource[] _audioSources;
    void Start()
    {
        _audioSources = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.volume = PlayerPrefs.GetFloat(volumeKey.Value) / 100;
        }
    }
}
