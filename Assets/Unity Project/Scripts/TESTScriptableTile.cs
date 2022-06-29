using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TESTScriptableTile : Tile
{
    private GameObject TriggerGameObject;

    private void Awake()
    {
        //
    }

    // Start is called before the first frame update
    void Start()
    {
        TriggerGameObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/TESTScriptableTile")]
    public static void CreateTESTScriptableTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save TESTScriptableTile", "New TESTScriptableTile", "Asset", "Save TESTScriptableTile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<TESTScriptableTile>(), path);
    }
#endif
}
