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
        LevelTileGOScript.RequestTileDelete += HandleRequestTileDelete;
        LevelTileGOScript.RequestTileRestore += HandleRequestTileRestore;
        LevelTileGOScript.RequestTileInteract += HandleRequestTileInteract;
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

    // + + + + | Event Handling | + + + + 

    private void HandleRequestTileDelete(Vector3 worldPosition)
    {
        var tilemapPosition = m_PhysEnviroTilemap.WorldToCell(worldPosition);
        Debug.Log($"Received request to DELETE tile at {worldPosition} -> {tilemapPosition}!");
        DeletePhysEnviroTileAt(tilemapPosition);
    }

    private void HandleRequestTileRestore(Vector3 worldPosition)
    {
        var tilemapPosition = m_PhysEnviroTilemap.WorldToCell(worldPosition);
        Debug.Log($"Received request to RESTORE tile at {worldPosition} -> {tilemapPosition}!");
        RestorePhysEnviroTileAt(tilemapPosition);
    }

    private void HandleRequestTileInteract(Vector3 worldPosition, bool isToggled)
    {
        var tileMapPosition = m_LevelTileTilemap.WorldToCell(worldPosition);
        Debug.Log($"Received request to INTERACT with tile at {worldPosition} -> {tileMapPosition}. Toggled: {isToggled}.");
        // TODO: IMPLEMENT INTERACTION ACTIONS somehow
    }

}
