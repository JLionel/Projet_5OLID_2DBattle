using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayName : MonoBehaviour
{
    [SerializeField] private TextMeshPro textName;
    [SerializeField] private int maxNameLength = 5;
    public PlayerIndexManager PlayerIndexManager;
    public PlayerNames PlayerNames;
    void Start()
    {
        textName.text = PlayerNames.Names[PlayerIndexManager.Index];
        
        if (textName.text.Length > maxNameLength)
        {
            textName.text = textName.text.Substring(0, maxNameLength) + "..";
        }
    }
}
