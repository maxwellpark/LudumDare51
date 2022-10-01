using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneLoader : StaticMonoBehaviour<UISceneLoader>
{
    private readonly string _uiSceneName = "UIScene";

    public void LoadUIScene(Scene currentScene, Scene nextScene)
    {
        LoadUIScene();
    }

    public void LoadUIScene()
    {
        var uiScene = SceneManager.GetSceneByName(_uiSceneName);

        if (!uiScene.isLoaded)
        {
            Debug.Log("Loading UI scene additively...");
            SceneManager.LoadSceneAsync(_uiSceneName, LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("UI scene is already loaded.");
        }
    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += LoadUIScene;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= LoadUIScene;
    }
}
