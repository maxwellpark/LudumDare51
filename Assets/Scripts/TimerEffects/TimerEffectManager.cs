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

    private TimerManager _timerManager;

    private void Start()
    {
        _debuffs = GetComponentsInChildren<Debuff>();
        _buffs = GetComponentsInChildren<Buff>();
    }

    private void ActivateRandomEffect()
    {
        var isBuff = Random.Range(0, 2) == 1;
        ActivateRandomEffect(isBuff);
    }

    private void ActivateRandomEffect(bool isBuff)
    {
        Debug.Log("Enabling random effect...");

        TimerEffect[] effects = isBuff ? _buffs : _debuffs;

        var inactiveEffects = effects.Where(eff => !eff.isActive);

        if (!inactiveEffects.Any())
        {
            Debug.LogWarning("No more available effects to activate.");
            return;
        }
        var index = Random.Range(0, _debuffs.Count());
        var effect = effects.ElementAt(index);
        Debug.Log("Enabling " + effect);
        effect.Activate();
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
