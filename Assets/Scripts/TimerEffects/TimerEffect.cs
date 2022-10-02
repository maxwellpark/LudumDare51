using UnityEngine;
using UnityEngine.Tilemaps;

public class TimerEffect : MonoBehaviour, ITimerEfect
{
    public virtual void Activate()
    {
        isActive = true;
    }

    public bool isActive;
    protected Tilemap _tilemap;
    public string readableName;

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
}
