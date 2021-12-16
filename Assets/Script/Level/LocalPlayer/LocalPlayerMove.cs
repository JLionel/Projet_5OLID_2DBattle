using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerMove : MonoBehaviour
{
    private string _playerName;

    public RoundCommand RoundCommand;

    public List<KeyCode> KeyPressed;
    public List<PlayerCommand> Commands;

    private void Start()
    {
        _playerName = name;
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Math.Min(KeyPressed.Count, Commands.Count); i++)
        {
            if(Input.GetKeyDown(KeyPressed[i]))
            {
                RoundCommand.Execute(_playerName, Commands[i]);
            }
        }
    }
}
