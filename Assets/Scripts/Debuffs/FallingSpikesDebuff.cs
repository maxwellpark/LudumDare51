using UnityEngine;

public class FallingSpikesDebuff : EnvironmentDebuff
{
    [SerializeField]
    private GameObject _spikePrefab;

    private int _xMin;
    private int _xMax;
    private int _y;

    public override void Activate()
    {
        SpawnSpike();
    }

    private GameObject SpawnSpike()
    {
        var position = GetNewSpikePosition();
        var obj = Instantiate(_spikePrefab, position, Quaternion.identity);
        return obj;
    }

    private Vector2 GetNewSpikePosition()
    {
        var x = Random.Range(_xMin, _xMax + 1);
        var position = new Vector2(x, _y);
        return position;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Debug.Log("Tile map size: " + _tilemap.size);
        Debug.Log("Map bounds min: " + _tilemap.cellBounds.min);
        Debug.Log("Map bounds max: " + _tilemap.cellBounds.max);

        _xMin = _tilemap.cellBounds.min.x + 1;
        _xMax = _tilemap.cellBounds.max.x - 1;
        _y = _tilemap.cellBounds.max.y;
    }

    // Update is called once per frame
    protected override void Update()
    {

    }
}
