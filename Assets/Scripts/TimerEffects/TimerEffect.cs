using UnityEngine;
using UnityEngine.Tilemaps;

public class TimerEffect : MonoBehaviour, ITimerEfect
{
    public virtual void AddPower()
    {
        if (!isActive)
        {
            isActive = true;
        }

        powerLevel++;
    }

    public bool isActive;
    protected Tilemap _tilemap;
    public string readableName;
    public int powerLevel = 0;

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
