using System.Collections;
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
    private SoundEffectManager _soundEffectManager;
    [SerializeField]
    private float _deathDelayInSeconds;

    // Start is called before the first frame update
    void Start()
    {
        _tilemapManager = TilemapManager.GetInstance();
        _soundEffectManager = SoundEffectManager.GetInstance();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            KillPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
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

    public void KillPlayer()
    {
        //_soundEffectManager.PlayEffectByName("TakeDamage");
        //StartCoroutine(DelayBeforeDeath());
        onPlayerKilled?.Invoke();
        gameObject.SetActive(false);
    }

    private IEnumerator DelayBeforeDeath()
    {
        yield return new WaitForSeconds(_deathDelayInSeconds);
    }
}
