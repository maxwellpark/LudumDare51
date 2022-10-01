using System;
using UnityEngine;
using UnityEngine.Events;

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
    public static event UnityAction onTimerTriggered;

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
    }

    public void ResetTimer()
    {
        _secondsPast = 0;
        _nextEventTimeInSeconds = _secondsBetweenEvents;
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
