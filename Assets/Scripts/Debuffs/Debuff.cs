using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Debuff : MonoBehaviour, IDebuff
{
    public abstract void Activate();

    public bool isActive;
    protected Tilemap _tilemap;

    protected virtual void Awake()
    {

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected void OnEnable()
    {

    }

    protected void OnDisable()
    {

    }
}
