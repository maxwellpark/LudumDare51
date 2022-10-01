using System;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : StaticMonoBehaviour<TimerManager>
{
    public TimeSpan CurrentTime;
    private float _secondsPast;
    private float _nextEventTimeInSeconds;

    [SerializeField]
    private float _secondsBetweenEvents = 10;

    // Fires every n seconds
    public static event UnityAction onTimerTriggered;

    // Start is called before the first frame update
    void Start()
    {
        _secondsPast = 0;
        _nextEventTimeInSeconds = _secondsBetweenEvents;
    }

    // Update is called once per frame
    void Update()
    {
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
