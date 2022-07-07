using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelTileBase : Tile
{
    //
#if UNITY_EDITOR
    [MenuItem("Assets/Create/2D/Tiles/LevelTile")]
    public static void CreateLevelTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save LevelTile", "New LevelTile", "Asset", "Save LevelTile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<LevelTileBase>(), path);
    }
#endif
}
