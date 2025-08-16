using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState gameState { get; private set; }

    public float currentGameSpeed { get; private set; } = 1f;

    private float defaultGameSpeed;

    public delegate void OnGameStateChange(GameState gameState);
    public OnGameStateChange onGameStateChange;

    [SerializeField] private float startTime = 180f; 
    private float currentTime;

    [SerializeField] private TextMeshProUGUI timerText;

    private int totalDragoonOrderComplete = 0;
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
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        defaultGameSpeed = currentGameSpeed;
        currentTime = startTime;
        gameState = GameState.InGame;
        StartGame();
        PopupUiManager.togglePopup?.Invoke(true, $"Help doki take care of her shop during her small break \n Q - Open potion tab \n W - Open Potion Guide \n E - Open Ingredient tab \n mix and match ingredient in the MAGICAL WASHING MACHINE to make a potion \n Once you have a potion drag it from the tab and give it to Dragoon to complete an order !");
    }

    void Update()
    {
        if(gameState == GameState.StartGame)
        {
            TimerCountdown();
        }
    }

    public void StartGame()
    {
        gameState = GameState.StartGame;
    }

    private void TimerCountdown()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            currentTime = Mathf.Max(currentTime, 0);

            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            TimerEnded();
        }
    }

    void TimerEnded()
    {
        gameState = GameState.EndGame;
        PotionManager.instance.ResetAllPotion();
        PopupUiManager.togglePopup?.Invoke(true, $"Thanks for covering me on my short break , Total Dragoon order complete {totalDragoonOrderComplete}");
        totalDragoonOrderComplete = 0;
    }

    public void OnDragoonOrderComplete()
    {
        totalDragoonOrderComplete++;
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
