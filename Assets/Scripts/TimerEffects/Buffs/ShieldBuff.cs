using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuff : Buff
{
    
    public override void AddPower()
    {
        base.AddPower();
        GameManager.Instance.playerAnimator.ToggleShield(true);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
