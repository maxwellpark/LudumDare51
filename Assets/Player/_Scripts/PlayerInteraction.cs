using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class PlayerInteraction : MonoBehaviour
{
    public TileBase currentTile;
    public event UnityAction onPlayerKilled;
    public bool touchingGround;
    public float timeOnGround;
    private TilemapManager _tilemapManager;

    // Start is called before the first frame update
    void Start()
    {
        _tilemapManager = TilemapManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        var cellPos = _tilemapManager.mainTilemap.WorldToCell(transform.position);
        currentTile = _tilemapManager.mainTilemap.GetTile(cellPos);

        if (touchingGround)
        {
            timeOnGround += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Hazard"))
        {
            KillPlayer();
        }

        if (collision.gameObject == _tilemapManager.collidableTilemap.gameObject)
        {
            Debug.Log("Colliding with ground");
            touchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == _tilemapManager.collidableTilemap.gameObject)
        {
            touchingGround = false;
            timeOnGround = 0f;
        }
    }

    private void KillPlayer()
    {
        onPlayerKilled?.Invoke();
        gameObject.SetActive(false);
    }


}
