using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StaticMonoBehaviour<GameManager>
{
    [SerializeField]
    private string _mainSceneName;

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(_mainSceneName);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
