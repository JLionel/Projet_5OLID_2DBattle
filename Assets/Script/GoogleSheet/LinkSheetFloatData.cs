using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu (menuName = "GoogleSheet/LinkData")]
public class LinkSheetFloatData : ScriptableObject
{
    [SerializeField] private TupleSheetData data;
    
    [SerializeField] private List<string> keyName;
    [SerializeField] private List<FloatVariable> value;

    private Dictionary<string, FloatVariable> _dataToLink;

    public void Init()
    {
        _dataToLink = new Dictionary<string, FloatVariable>();
        for (int i = 0; i < keyName.Count; i++)
        {
            _dataToLink.Add(keyName[i], value[i]);
        }
    }

    public void LinkData()
    {
        foreach (var tuple in data.Value)
        {
            if (_dataToLink.ContainsKey(tuple.Name))
            {
                _dataToLink[tuple.Name].Value = tuple.Value;
            }
        }
    }
}
