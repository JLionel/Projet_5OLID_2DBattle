using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TurnCube : MonoBehaviour
{
    private void Start()
    {
        Application.runInBackground = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(Random.value * 180, Random.value * 180, Random.value * 180, Random.value);
    }
}
