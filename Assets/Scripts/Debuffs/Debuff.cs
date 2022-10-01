using UnityEngine;

public abstract class Debuff : MonoBehaviour, IDebuff
{
    public abstract void Activate();

    protected virtual void Awake()
    {

    }

    // Start is called before the first frame update
    protected virtual void Start()
    {

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
