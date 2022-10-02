using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _currentTimeTxt;
    [SerializeField]
    private TMP_Text _bestTimeTxt;

    private TimerManager _timerManager;

    private void Start()
    {
        _timerManager = TimerManager.GetInstance();
        _currentTimeTxt.text = "";
        _bestTimeTxt.text = "";
        _currentTimeTxt.gameObject.SetActive(true);
        _bestTimeTxt.gameObject.SetActive(_timerManager.BestTime.Milliseconds > 0);
    }

    private void Update()
    {
        if (_timerManager.timerStopped)
            return;

        _currentTimeTxt.text = FormatText(_timerManager.CurrentTime);
        _bestTimeTxt.text = FormatText(_timerManager.BestTime);
    }

    private string FormatText(TimeSpan time)
    {
        var text = string.Format(CultureInfo.CurrentCulture, "{0}:{1}:{2}",
            time.Minutes,
            time.Seconds,
            time.Milliseconds);

        return text;
    }
}
