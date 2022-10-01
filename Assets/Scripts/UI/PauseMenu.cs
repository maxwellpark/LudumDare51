using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _container;

    [SerializeField]
    private Button _resumeButton;

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private Button _quitButton;

    private GameManager _gameManager;

    private void ShowPauseMenu(bool paused)
    {
        _container.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        _gameManager = GameManager.GetInstance();
        ShowPauseMenu(false);

        _quitButton.onClick.RemoveAllListeners();
        _quitButton.onClick.AddListener(() => ShowPauseMenu(true));

        _resumeButton.onClick.RemoveAllListeners();
        _resumeButton.onClick.AddListener(() => ShowPauseMenu(false));

        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(_gameManager.RestartGame);
    }

    private void OnDisable()
    {
        if (_quitButton != null)
            _quitButton.onClick.RemoveAllListeners();

        if (_resumeButton != null)
            _resumeButton.onClick.RemoveAllListeners();

        if (_restartButton != null)
            _restartButton.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_container.activeSelf)
            {
                ShowPauseMenu(!_container.activeSelf);
            }
            else
            {
                ShowPauseMenu(false);
            }
        }
    }
}
