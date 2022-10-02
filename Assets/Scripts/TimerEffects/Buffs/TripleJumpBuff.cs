using TarodevController;
using UnityEngine;

public class TripleJumpBuff : Buff
{
    [SerializeField]
    private ScriptableStats _stats;

    protected override void Start()
    {
        base.Start();
        _stats.AllowTripleJump = false;
    }

    public override void AddPower()
    {
        base.AddPower();
        _stats.AllowTripleJump = true;
    }
}
