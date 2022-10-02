using UnityEngine.Tilemaps;

public class Debuff : TimerEffect
{
    // Start is called before the first frame update
    protected override void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }
}
