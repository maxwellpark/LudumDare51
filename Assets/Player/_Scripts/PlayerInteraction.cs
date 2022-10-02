using System.Collections;
using TarodevController;
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
        if (GameManager.Instance.playerAnimator.HasShield)
        {
            GameManager.Instance.playerAnimator.ToggleShield(false);
            return;
        }
        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        // Play sound effect, then have a time delay before invoking the event
        _soundEffectManager.PlayEffectByName("TakeDamage");
        GameManager.Instance.player.GetComponent<PlayerController>().TakeAwayControl(true);
        GameManager.Instance.player.GetComponentInChildren<PlayerAnimator>().DisableAnimator();
        AlertsManager.Instance.SetGameOverAlertActive(true);
        yield return new WaitForSeconds(_deathDelayInSeconds);

        onPlayerKilled?.Invoke();
        gameObject.SetActive(false);
    }
}
