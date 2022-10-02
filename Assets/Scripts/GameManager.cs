using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : StaticMonoBehaviour<GameManager>
{
    [SerializeField]
    private GameData _gameData;

    public GameObject player;

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(_gameData.mainSceneName);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        var interaction = player.GetComponent<PlayerInteraction>();
        interaction.onPlayerKilled += RestartGame;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
