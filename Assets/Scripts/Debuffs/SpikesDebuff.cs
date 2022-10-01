using UnityEngine;

public class SpikesDebuff : Debuff
{
    [SerializeField]
    private GameObject _spikePrefab;

    public override void Activate()
    {
        SpawnSpike();
    }

    private GameObject SpawnSpike()
    {
        var position = new Vector2(0, 0);
        var obj = Instantiate(_spikePrefab, position, Quaternion.identity);
        return obj;
    }

    // Start is called before the first frame update
    protected override void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {

    }
}
