using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    [SerializeField] private List<MyMonoBehaviour> _components;
    private void Update()
    {
        for (int i = 0; i < _components.Count; i++)
        {
            _components[i].DoUpdate();
        }
    }
}