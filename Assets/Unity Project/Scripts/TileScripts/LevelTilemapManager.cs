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
            DeletePhysEnviroTile(new Vector3Int(i, i, 0));
        }

        string deletedTileString = string.Empty;
        foreach (Vector3Int position in m_DeletedPhysEnviroTiles.Keys)
        {
            deletedTileString += $"({position.ToString()}, {m_DeletedPhysEnviroTiles[position].ToString()})" + "\n";
        }
        Debug.Log("We have deleted tiles: " + deletedTileString);
    }

    // + + + + | Functions | + + + + 

    private void DeletePhysEnviroTile(Vector3Int position)
    {
        var tileToDelete = m_PhysEnviroTilemap.GetTile(position);

        if (tileToDelete)
        {
            Debug.Log($"Deleting {tileToDelete} at position {position}!");
            m_DeletedPhysEnviroTiles.Add(position, tileToDelete);
            m_PhysEnviroTilemap.SetTile(position, null);
        }
        else
        {
            Debug.Log($"No Phys Tile found at {position}");
        }
    }
}
