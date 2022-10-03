using System.Linq;
using UnityEngine;

public class SoundEffectManager : StaticMonoBehaviour<SoundEffectManager>
{
    [SerializeField]
    private SoundEffect[] _effects;

    [SerializeField]
    private float _audioSrcVolume = 0.75f;

    public void Init()
    {
        if (_effects == null)
        {
            Debug.LogWarning("No SFX objects assigned in inspector");
            return;
        }

        // Create audio source for each scriptable object 
        foreach (var effect in _effects)
        {
            var obj = new GameObject(effect.effectName + " src");
            obj.transform.parent = transform;
            var src = obj.AddComponent<AudioSource>();
            src.loop = false;
            src.volume = _audioSrcVolume;
            src.enabled = true;
            src.clip = effect.clip;
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
        if (effect.src != null)
        {
            effect.src.Stop();
            effect.src.Play();
        }
    }
}
