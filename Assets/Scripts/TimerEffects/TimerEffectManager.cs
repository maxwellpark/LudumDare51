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

    public List<TimerEffect> AvailableTimerEffects => AllTimerEffects
        .Where(eff => !(eff.isActive && !eff.isStackable))
        .ToList();

    private TimerManager _timerManager;

    private void Start()
    {
        _debuffs = GetComponentsInChildren<Debuff>();
        _buffs = GetComponentsInChildren<Buff>();

        AllTimerEffects = new List<TimerEffect>();
        AllTimerEffects.AddRange(_debuffs);
        AllTimerEffects.AddRange(_buffs);
        ActivateRandomEffect();
    }

    private void ActivateRandomEffect()
    {
        var index = Random.Range(0, AvailableTimerEffects.Count);
        var effect = AvailableTimerEffects.ElementAt(index);

        if (effect is Buff)
        {
            SoundEffectManager.Instance.PlayEffectByName("PowerUp");
        }
        else if (effect is Debuff)
        {
            // Play debuff sound 
        }

        effect.AddPower();
    }

    public void DeactivateShield()
    {
        var shield = AllTimerEffects.FirstOrDefault(eff => eff is ShieldBuff);
        if (shield != null)
        {
            var buff = shield as ShieldBuff;
            buff.RemovePower();
        }
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
