using System.Linq;
using UnityEngine;

public class SoundEffectManager : StaticMonoBehaviour<SoundEffectManager>
{
    [SerializeField]
    private AudioSource _sfxSrc;

    [SerializeField]
    private SoundEffect[] _effects;

    public void Init()
    {
        if (_effects == null)
        {
            Debug.LogWarning("No SFX objects assigned in inspector");
            return;
        }

        foreach (var effect in _effects)
        {
            var obj = new GameObject(effect.effectName + " src");
            obj.transform.parent = transform;
            var src = obj.AddComponent<AudioSource>();
            src.loop = false;
            effect.src = src;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void PlayEffectByName(string name)
    {
        name = name.ToUpper();
        var effect = _effects.FirstOrDefault(eff => eff.effectName.ToUpper() == name);
        effect.src.Stop();
        effect.src.Play();
    }
}
