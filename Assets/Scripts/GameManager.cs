using TarodevController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StaticMonoBehaviour<GameManager>
{
    [SerializeField]
    private GameData _gameData;

    public GameObject player;
    public PlayerAnimator playerAnimator;
    
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(_gameData.mainSceneName);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        var interaction = player.GetComponent<PlayerInteraction>();
        interaction.onPlayerKilled += RestartGame;

        playerAnimator = player.GetComponentInChildren<PlayerAnimator>();
    }

    void Update()
    {

    }
}
