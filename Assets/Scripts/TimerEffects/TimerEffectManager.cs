using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerEffectManager : StaticMonoBehaviour<TimerEffectManager>
{
    private Debuff[] _debuffs;
    private Buff[] _buffs;

    public List<TimerEffect> CurrentBuffs
    {
        get
        {
            List<TimerEffect> toReturn = new List<TimerEffect>();
            toReturn.AddRange(_buffs.Where(eff => eff.isActive));
            return toReturn;
        }
    }

    public List<TimerEffect> CurrentDebuffs
    {
        get
        {
            List<TimerEffect> toReturn = new List<TimerEffect>();
            toReturn.AddRange(_debuffs.Where(eff => eff.isActive));
            return toReturn;
        }
    }

    public List<TimerEffect> AllTimerEffects { get; private set; }

    private TimerManager _timerManager;

    private void Start()
    {
        _debuffs = GetComponentsInChildren<Debuff>();
        _buffs = GetComponentsInChildren<Buff>();

        AllTimerEffects = new List<TimerEffect>();
        AllTimerEffects.AddRange(_debuffs);
        AllTimerEffects.AddRange(_buffs);
    }

    private void ActivateRandomEffect()
    {
        var index = Random.Range(0, AllTimerEffects.Count);
        var effect = AllTimerEffects.ElementAt(index);
        effect.AddPower();
    }

    private void OnEnable()
    {
        _timerManager = TimerManager.GetInstance();
        _timerManager.onTimerTriggered += ActivateRandomEffect;
    }

    private void OnDisable()
    {
        _timerManager.onTimerTriggered -= ActivateRandomEffect;
    }
}
