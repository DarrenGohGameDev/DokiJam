using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState { get; private set; }

    public float currentGameSpeed { get; private set; } = 1f;

    private float defaultGameSpeed;

    public delegate void OnGameStateChange(GameState gameState);
    public OnGameStateChange onGameStateChange;

    public enum GameState
    {
        StartGame,
        InGame,
        PauseGame,
        EndGame,
    }

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        defaultGameSpeed = currentGameSpeed;
        gameState = GameState.InGame;
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            if (gameState == GameState.PauseGame)
            {
                TogglePauseGame(false);
            }
            else
            {
                TogglePauseGame(true);
            }
        }
    }

    public void TogglePauseGame(bool toggle)
    {
        if (toggle)
        {
            gameState = GameState.PauseGame;
            currentGameSpeed = 0;
            onGameStateChange?.Invoke(GameState.PauseGame);
        }
        else
        {
            gameState = GameState.InGame;
            currentGameSpeed = defaultGameSpeed;
            onGameStateChange?.Invoke(GameState.InGame);
        }

    }
}
