using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level/TileEntities")]
public class TileEntities : TileData
{
    private Dictionary<Vector2Int, Entity> _tileEntitiesList = new Dictionary<Vector2Int, Entity>();

    //////////////
    public List<Vector2Int> Pos = new List<Vector2Int>();
    public List<Entity> Ent = new List<Entity>();
    //////////////
    
    public override void Init()
    {
        _tileEntitiesList = new Dictionary<Vector2Int, Entity>();

        //////////////
        Pos = new List<Vector2Int>();
        Ent = new List<Entity>();
        //////////////
    }

    public override void AddNew(Vector2Int Position)
    {
        _tileEntitiesList.Add(Position, null);

        //////////////
        Pos.Add(Position);
        Ent.Add(null);
        //////////////
    }

    public bool IsTileFree(Vector2Int Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) return false;
        if (!_tileEntitiesList[Position]) { return true; }
        return false;
    }

    public Entity GetEntity(Vector2Int Position)
    {
        if (!_tileEntitiesList.ContainsKey(Position)) { return null; }
        return _tileEntitiesList[Position];
    }

    public void SetEntity(Vector2Int Position, Entity Entity)
    {
        _tileEntitiesList[Position] = Entity;

        //////////////
        for (int i = 0; i < Pos.Count; i++)
        {
            if (Pos[i] == Position)
            {
                Ent[i] = Entity;
            }
        }
        //////////////
    }
}
