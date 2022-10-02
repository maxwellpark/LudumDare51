using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MusicState
{
    Menu, InGame, None
}

public class MusicManager : StaticMonoBehaviour<MusicManager>
{
    [SerializeField]
    private AudioSource menuSrc;

    [SerializeField]
    private AudioSource inGameSrc;

    private AudioSource _currentSrc;

    [SerializeField]
    private GameData _gameData;

    private Dictionary<MusicState, AudioSource> _srcMap;

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    private void Start()
    {
    }

    private void Init()
    {
        menuSrc.enabled = true;
        inGameSrc.enabled = true;

        _srcMap = new Dictionary<MusicState, AudioSource>
        {
            { MusicState.Menu, menuSrc },
            { MusicState.InGame, inGameSrc },
            { MusicState.None, null }
        };
        _currentSrc = null;
        SceneManager.activeSceneChanged += (c, a) => OnSceneChangedHandler();
        PlayMusic();
    }

    public void PlayMusic()
    {
        var state = GetStateByScene(SceneManager.GetActiveScene().name);
        PlayMusic(state);
    }

    public void PlayMusic(MusicState state)
    {
        var src = GetSrcByState(state);

        if (src == null || src.isPlaying)
            return;

        ResetSrcs();
        src.Play();
        _currentSrc = src;
    }

    private void OnSceneChangedHandler()
    {
        PlayMusic();
    }

    private void ResetSrcs()
    {
        menuSrc.Stop();
        inGameSrc.Stop();
        menuSrc.Stop();
    }

    private AudioSource GetSrcByState(MusicState state)
    {
        Debug.Log("Getting audio src by music state: " + state);

        if (_srcMap.ContainsKey(state))
            return _srcMap[state];

        Debug.LogWarning("No item exists in src map with state key: " + state);
        return null;
    }

    public MusicState GetStateBySrc(AudioSource src)
    {
        foreach (var item in _srcMap)
        {
            if (item.Value == src)
                return item.Key;
        }
        Debug.LogWarning("No key found in src map for audio src: " + src);
        return MusicState.None;
    }

    public MusicState GetStateByScene(string sceneName)
    {
        Debug.Log("Getting music state for scene: " + sceneName);
        sceneName = sceneName.ToUpper();

        if (sceneName == _gameData.mainMenuSceneName.ToUpper())
            return MusicState.Menu;

        if (sceneName == _gameData.mainSceneName.ToUpper())
            return MusicState.InGame;

        Debug.LogWarning("No key found in scene map with key: " + sceneName);
        return MusicState.None;
    }

    public MusicState GetCurrentState()
    {
        var state = GetStateBySrc(_currentSrc);
        return state;
    }
}
