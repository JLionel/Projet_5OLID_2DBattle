using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    [SerializeField] private List<MyMonoBehaviour> _components;
    private void Start()
    {
        foreach (var component in _components)
        {
            component.DoStart();
        }
    }
    private void Update()
    {
        foreach (var component in _components)
        {
            component.DoUpdate();
        }
    }
}