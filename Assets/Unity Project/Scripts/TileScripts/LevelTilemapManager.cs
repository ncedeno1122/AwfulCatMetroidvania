using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelTilemapManager : MonoBehaviour
{
    private Dictionary<Vector3Int, TileBase> m_DeletedPhysEnviroTiles = new();

    public Tilemap m_PhysEnviroTilemap;
    public Tilemap m_LevelTileTilemap;

    private void OnValidate()
    {
        if (m_PhysEnviroTilemap != null &&
            m_LevelTileTilemap != null) return;

        foreach(Transform child in transform)
        {
            if (m_PhysEnviroTilemap == null && child.name.Equals("PhysEnviroTilemap"))
            {
                m_PhysEnviroTilemap = child.GetComponent<Tilemap>();
            }
            if (m_LevelTileTilemap == null && child.name.Equals("LevelTileTilemap"))
            {
                m_LevelTileTilemap = child.GetComponent<Tilemap>();
            }
        }
    }

    private void Start()
    {
        for (int i = -7; i < 7; i++)
        {
            DeletePhysEnviroTileAt(new Vector3Int(i, i, 0));
        }

        for (int i = -2; i < 2; i++)
        {
            RestorePhysEnviroTileAt(new Vector3Int(i, i, 0));
        }
    }

    // + + + + | Functions | + + + + 

    private void DeletePhysEnviroTileAt(Vector3Int position)
    {
        var tileToDelete = m_PhysEnviroTilemap.GetTile(position);

        if (tileToDelete)
        {
            m_DeletedPhysEnviroTiles.Add(position, tileToDelete);
            m_PhysEnviroTilemap.SetTile(position, null);
            //Debug.Log($"Deleted {tileToDelete} at position {position}!");
        }
        else
        {
            Debug.Log($"No Phys Tile found at {position}");
        }
    }

    private bool IsDeletedPhysEnviroTileAt(Vector3Int position) => m_DeletedPhysEnviroTiles.ContainsKey(position);

    private void RestorePhysEnviroTileAt(Vector3Int position)
    {
        if (IsDeletedPhysEnviroTileAt(position))
        {
            var tileToRestore = m_DeletedPhysEnviroTiles[position];
            m_DeletedPhysEnviroTiles.Remove(position);
            m_PhysEnviroTilemap.SetTile(position, tileToRestore);
            //Debug.Log($"Restored {tileToRestore} at position {position}!");
        }
    }
}
