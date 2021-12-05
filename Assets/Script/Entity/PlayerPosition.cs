using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerPosition")]
public class PlayerPosition : ScriptableObject
{
    public GameEvent PlayerPositionChanged;
    [SerializeField]
    private Vector2 _position;

    public void SetValue(Vector2 Position)
    {
        _position = Position;
        PlayerPositionChanged.Raise();
    }
    public void AddValue(Vector2 Position)
    {
        _position += Position;
        PlayerPositionChanged.Raise();
    }

    public Vector2 GetValue()
    {
        return _position;
    }
}