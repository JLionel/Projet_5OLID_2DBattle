using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private List<StringVariable> scenesToLoad;
    [SerializeField] private List<StringVariable> scenesToUnload;

    private void Start()
    {
        UnloadAll();
        LoadAll();
    }

    private void LoadAll()
    {
        Debug.Log("Loading started");
        foreach (var scene in scenesToLoad)
        {
            SceneManager.LoadScene(scene.Value, LoadSceneMode.Additive);
        }

        Debug.Log("Loading done");
    }

    private void UnloadAll()
    {
        Debug.Log("Unloading started");
        
        foreach (var scene in scenesToUnload)
        {
            SceneManager.UnloadSceneAsync(scene.Value);
        }
        
        Debug.Log("Unloading done");
    }
}
