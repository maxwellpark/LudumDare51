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
    [SerializeField]
    private TMP_Text _bestTimeLabel;

    private TimerManager _timerManager;

    private void Start()
    {
        _timerManager = TimerManager.GetInstance();
        _currentTimeTxt.text = "";
        _bestTimeTxt.text = "";
        _currentTimeTxt.gameObject.SetActive(true);
        _bestTimeTxt.gameObject.SetActive(_timerManager.BestTime.Milliseconds > 0);
        _bestTimeLabel.gameObject.SetActive(_timerManager.BestTime.Milliseconds > 0);
    }

    private void Update()
    {
        if (_timerManager.timerStopped)
            return;

        _currentTimeTxt.text = $"{_timerManager.CurrentTime.ToString(@"mm\:ss\.fff")}";
        _bestTimeTxt.text = $"{_timerManager.BestTime.ToString(@"mm\:ss\.fff")}";
    }
}
