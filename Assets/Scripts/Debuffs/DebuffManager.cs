using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebuffManager : StaticMonoBehaviour<DebuffManager>
{
    [SerializeField]
    private List<Debuff> _debuffs;

    // Start is called before the first frame update
    void Start()
    {
        TimerManager.onTimerTriggered += ActivateRandomDebuff;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ActivateRandomDebuff()
    {
        Debug.Log("Enabling random debuff...");
        var index = Random.Range(0, _debuffs.Count);
        var debuff = _debuffs.ElementAt(index);
        Debug.Log("Enabling " + debuff);
        debuff.Activate();
    }
}
