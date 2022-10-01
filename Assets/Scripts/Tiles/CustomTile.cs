using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TerrainType
{
    Floor, Wall, Ceiling, Platform
}

public class CustomTile : Tile
{
    [Space]
    [Header("Custom fields")]
    public TerrainType terrainType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a CustomTile Asset
    [MenuItem("Assets/Create/CustomTiles/CustomTile")]
    public static void CreateCustomTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save CustomTile", "New CustomTile", "Asset", "Save Road Tile", "Assets/ScriptableObjects/CustomTiles");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(CreateInstance<CustomTile>(), path);
    }
#endif
}
