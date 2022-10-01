using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class TimerManager : StaticMonoBehaviour<TimerManager>
{
    public static TimeSpan CurrentTime;
    private float _secondsPast;
    private float _nextEventTimeInSeconds;

    [SerializeField]
    private float _secondsBetweenEvents = 10;

    // Fires every n seconds
    public static event UnityAction onTimerTriggered;

    // Start is called before the first frame update
    void Start()
    {
        _nextEventTimeInSeconds = _secondsBetweenEvents;
    }

    // Update is called once per frame
    void Update()
    {
        _secondsPast += Time.deltaTime;
        CurrentTime = TimeSpan.FromSeconds(_secondsPast);

        var timeStr = string.Format(CultureInfo.CurrentCulture, "{0}:{1}:{2}",
            CurrentTime.Minutes,
            CurrentTime.Seconds,
            CurrentTime.Milliseconds);

        //Debug.Log("Time: " + timeStr);

        if (_secondsPast >= _nextEventTimeInSeconds)
        {
            // Trigger event
            Debug.Log($"Timer triggered after {_nextEventTimeInSeconds} seconds.");
            _nextEventTimeInSeconds += _secondsBetweenEvents;
            onTimerTriggered?.Invoke();
        }
    }
}
