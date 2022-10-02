using UnityEngine;

public class Spike : HazardousObject
{
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
