using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingSpikesDebuff : EnvironmentDebuff
{
    [SerializeField]
    private GameObject _spikePrefab;

    public Bounds spawnBounds;

    [SerializeField]
    private float _timeDelayInSeconds = 1f;
    private float _timer;

    public override void AddPower()
    {
        base.AddPower();
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
        var x = Random.Range(spawnBounds.min.x, spawnBounds.max.x);
        var y = Random.Range(spawnBounds.min.y, spawnBounds.max.y);
        var position = new Vector2(x, y);
        return position;
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (!isActive)
            return;

        _timer += Time.deltaTime;

        if (_timer >= _timeDelayInSeconds / powerLevel)
        {
            SpawnSpike();
            _timer = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnBounds.center, spawnBounds.size);
    }
}
