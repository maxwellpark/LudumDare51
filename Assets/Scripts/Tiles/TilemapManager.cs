using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : StaticMonoBehaviour<TilemapManager>
{
    public Tilemap mainTilemap;
    public Tilemap collidableTilemap;

    protected override void Awake()
    {
        base.Awake();
        var mainTilemapObj = GameObject.FindWithTag("MainTilemap");
        mainTilemap = mainTilemapObj.GetComponent<Tilemap>();

        var collidableTilemapObj = GameObject.FindWithTag("CollidableTilemap");
        collidableTilemap = collidableTilemapObj.GetComponent<Tilemap>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
