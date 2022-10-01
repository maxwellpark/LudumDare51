using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _timerText;
    private TimerManager _timerManager;

    private void Start()
    {
        _timerManager = TimerManager.GetInstance();
    }

    private void Update()
    {
        _timerText.text = FormatText();
    }

    private string FormatText()
    {
        var text = string.Format(CultureInfo.CurrentCulture, "{0}:{1}:{2}",
            _timerManager.CurrentTime.Minutes,
            _timerManager.CurrentTime.Seconds,
            _timerManager.CurrentTime.Milliseconds);

        return text;
    }
}
