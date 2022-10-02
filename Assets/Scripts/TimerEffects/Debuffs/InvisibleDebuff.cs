using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class InvisibleDebuff : Debuff
{
    
    public override void AddPower()
    {
        base.AddPower();
        GameManager.Instance.playerAnimator.MakePlayerInvisible();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
