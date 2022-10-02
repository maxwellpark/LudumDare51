using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebuffManager : StaticMonoBehaviour<DebuffManager>
{
    [SerializeField]
    private List<Debuff> _debuffs;

    private TimerManager _timerManager;

    private void ActivateRandomDebuff()
    {
        Debug.Log("Enabling random debuff...");
        var index = Random.Range(0, _debuffs.Count);
        var debuff = _debuffs.ElementAt(index);
        Debug.Log("Enabling " + debuff);
        debuff.Activate();
    }

    private void OnEnable()
    {
        _timerManager = TimerManager.GetInstance();
        _timerManager.onTimerTriggered += ActivateRandomDebuff;
    }

    private void OnDisable()
    {
        _timerManager.onTimerTriggered -= ActivateRandomDebuff;
    }
}
