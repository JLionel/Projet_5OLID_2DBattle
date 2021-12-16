using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
    [SerializeField] private List<OrdonedMonoBehaviour> awakeComponents;
    [SerializeField] private List<OrdonedMonoBehaviour> updateComponents;

    void Awake()
    {
        for (int i = 0; i < awakeComponents.Count; i++)
        {
            awakeComponents[i].DoAwake();
        }
    }
    void Update()
    {
        for (int i = 0; i < updateComponents.Count; i++)
        {
            updateComponents[i].DoUpdate();
        }
    }
}