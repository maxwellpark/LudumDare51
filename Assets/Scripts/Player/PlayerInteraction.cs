using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{
    private Tilemap _tilemap;
    public TileBase currentTile;
    public event UnityAction onPlayerKilled;

    // Start is called before the first frame update
    void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        var cellPos = _tilemap.WorldToCell(transform.position);
        currentTile = _tilemap.GetTile(cellPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        onPlayerKilled?.Invoke();
        gameObject.SetActive(false);
    }
}
