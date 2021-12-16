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

    public override void AddNew(Vector2Int position)
    {
        _tileEntitiesList.Add(position, null);

        //////////////
        Pos.Add(position);
        Ent.Add(null);
        //////////////
    }

    public int TilePlayer(Vector2Int position)
    {
        if (!_tileEntitiesList.ContainsKey(position)) return -1;
        Entity entity = _tileEntitiesList[position];
        if (!(entity is Player)) { return -1; }
        Player player = (Player)entity;
        PlayerIndexManager playerIndexManager = player.gameObject.GetComponent<PlayerIndexManager>();
        if (!playerIndexManager) { return -1; }
        return playerIndexManager.Index;
    }

    public Entity GetEntity(Vector2Int position)
    {
        if (!_tileEntitiesList.ContainsKey(position)) { return null; }
        return _tileEntitiesList[position];
    }

    public void SetEntity(Vector2Int position, Entity entity)
    {
        _tileEntitiesList[position] = entity;

        //////////////
        for (int i = 0; i < Pos.Count; i++)
        {
            if (Pos[i] == position)
            {
                Ent[i] = entity;
            }
        }
        //////////////
    }
}
