using UnityEngine;

public class HotFloorDebuff : EnvironmentDebuff
{
    private GameManager _gameManager;
    [SerializeField]
    private float _timeLimitInSeconds = 2.5f;
    private PlayerInteraction _interaction;

    public override void AddPower()
    {
        base.AddPower();
        _interaction = _gameManager.player.GetComponent<PlayerInteraction>();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _gameManager = GameManager.GetInstance();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (!isActive)
            return;

        if (_interaction.timeOnGround >= _timeLimitInSeconds)
        {
            Debug.Log("Hot floor time limit reached.");
            _interaction.KillPlayer();
        }
    }
}
