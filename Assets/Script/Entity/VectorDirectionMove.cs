using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorDirectionMove
{
    public static Vector2 FetchDirection(DirectionMove directionMove)
    {
        switch (directionMove)
        {
          case  DirectionMove.Up:
              return Vector2.up;
          case  DirectionMove.Down:
              return Vector2.down;
          case  DirectionMove.Left:
              return Vector2.left;
          case  DirectionMove.Right:
              return Vector2.right;
          default: return Vector2.zero;
        }
    }
}

public enum DirectionMove
{
    Up,
    Down,
    Left,
    Right
}

