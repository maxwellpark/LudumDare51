using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FloorTile : Tile
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a FloorTile Asset
    [MenuItem("Assets/Create/CustomTiles/FloorTile")]
    public static void CreateRoadTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save FloorTile", "New FloorTile", "Asset", "Save Road Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(CreateInstance<FloorTile>(), path);
    }
#endif
}
