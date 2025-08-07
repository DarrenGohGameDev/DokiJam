using UnityEngine;
using static GameManager;

public class SaveManager : MonoBehaviour
{
    public delegate void OnSaveGame();
    public OnSaveGame onSaveGame;

    [SerializeField] private PlayerStat playerStat;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        onSaveGame += SaveGame;
    }

    private void OnDisable()
    {
        onSaveGame -= SaveGame;
    }

    private void SaveGame()
    {
        PlayerPrefs.SetFloat("playerShopRep", playerStat.shopReputaation);
        PlayerPrefs.SetInt("playerTotalDayShopOpen", playerStat.totalDaysShopIsOpen);
        PlayerPrefs.SetInt("playerTotalGold", playerStat.playerTotalGold);
    }
}
