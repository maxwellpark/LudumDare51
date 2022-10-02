using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimerManager : StaticMonoBehaviour<TimerManager>
{
    public TimeSpan CurrentTime { get; private set; }
    public TimeSpan BestTime { get; private set; } = new TimeSpan(0, 0, 0);

    private float _secondsPast;
    private float _nextEventTimeInSeconds;

    public bool timerStopped;

    [SerializeField]
    private float _secondsBetweenEvents = 10;

    // Fires every n seconds
    public event UnityAction onTimerTriggered;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += (c, a) => Init();
    }

    private void Init()
    {
        var player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            var interaction = player.GetComponent<PlayerInteraction>();
            interaction.onPlayerKilled += OnKilledHandler;
        }
        ResetTimer();
    }

    public void ResetTimer()
    {
        _secondsPast = 0;
        _nextEventTimeInSeconds = _secondsBetweenEvents;
    }

    private void OnKilledHandler()
    {
        if (CurrentTime > BestTime)
        {
            BestTime = CurrentTime;
        }
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStopped)
            return;

        _secondsPast += Time.deltaTime;
        CurrentTime = TimeSpan.FromSeconds(_secondsPast);

        if (_secondsPast >= _nextEventTimeInSeconds)
        {
            // Trigger event
            Debug.Log($"Timer triggered after {_nextEventTimeInSeconds} seconds.");
            _nextEventTimeInSeconds += _secondsBetweenEvents;
            onTimerTriggered?.Invoke();
        }
    }
}
