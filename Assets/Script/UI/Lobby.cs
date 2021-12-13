using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private PlayerNames playerNames;

    [SerializeField] private TextMeshProUGUI listText;
    
    public void UpdateList()
    {
        listText.text += playerNames.Names.Last() + "\n";
    }
}
