using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerEffectsUI : MonoBehaviour
{

    [SerializeField] private TMP_Text buffsText;
    [SerializeField] private TMP_Text debuffsText;
    
    void Start()
    {
        
    }

    void Update()
    {
        SetBuffs();
        SetDebuffs();
    }

    void SetBuffs()
    {
        string text = "Buffs\n";
        foreach (TimerEffect effect in TimerEffectManager.Instance.CurrentBuffs)
        {
            text += $"{effect.readableName} {effect.powerLevel}\n";
        }

        buffsText.text = text;
    }
    
    void SetDebuffs()
    {
        string text = "Debuffs\n";
        foreach (TimerEffect effect in TimerEffectManager.Instance.CurrentDebuffs)
        {
            text += $"{effect.readableName} {effect.powerLevel}\n";
        }

        debuffsText.text = text;
    }
}
