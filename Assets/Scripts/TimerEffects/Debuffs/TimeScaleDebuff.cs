using UnityEngine;

public class TimeScaleDebuff : Debuff
{
    [SerializeField]
    private float _timeScaleIncrement = 0.1f;

    public override void AddPower()
    {
        base.AddPower();
        Time.timeScale = 1 + (powerLevel * _timeScaleIncrement);
    }
}
