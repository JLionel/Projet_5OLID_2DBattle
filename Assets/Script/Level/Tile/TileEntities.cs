using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/TileEntities")]
public class TileEntities : TilesData
{
    private Dictionary<Vector2, Entity> _tileEntitiesList = new Dictionary<Vector2, Entity>();

    public override void Init()
    {
        _tileEntitiesList = new Dictionary<Vector2, Entity>();
    }

    public override void AddNew(Vector2 Position)
    {
        _tileEntitiesList.Add(Position, null);
    }

    public bool IsTileFree(Vector2 Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) return false;
        if (!_tileEntitiesList[Position]) { return true; }
        return false;
    }

    public Entity GetEntity(Vector2 Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) { return null; }
        return _tileEntitiesList[Position];
    }

    public void SetEntity(Vector2 Position, Entity Entity)
    {
        _tileEntitiesList[Position] = Entity;
    }
}
