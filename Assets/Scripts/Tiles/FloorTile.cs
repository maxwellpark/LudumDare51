using UnityEditor;

public class FloorTile : CustomTile
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
    public static void CreateFloorTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save FloorTile", "New FloorTile", "Asset", "Save Road Tile", "Assets/ScriptableObjects/CustomTiles");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(CreateInstance<FloorTile>(), path);
    }
#endif
}
