using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UISceneLoader : StaticMonoBehaviour<UISceneLoader>
{
    private static readonly string _uiSceneName = "UIScene";

    [SerializeField]
    private string[] _blacklistedScenes;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void SceneChangedHandler(Scene currentScene, Scene nextScene)
    {
        Debug.Log($"Moving from {currentScene} to {nextScene}");
        var uiScene = SceneManager.GetSceneByName(_uiSceneName);

        if (_blacklistedScenes.Contains(nextScene.name))
        {
            Debug.Log("UI scene blacklisted on current scene. Will not load.");

            if (uiScene.isLoaded)
                SceneManager.UnloadSceneAsync(uiScene.name);

            return;
        }

        if (!uiScene.isLoaded)
        {
            LoadScene();
        }
        else
        {
            Debug.Log("UI scene is already loaded.");
        }
    }

    private void LoadScene()
    {
        Debug.Log("Loading UI scene additively...");
        SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += SceneChangedHandler;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= SceneChangedHandler;
    }
}
