using UnityEngine;
using static GameManager;

public class SaveManager : MonoBehaviour
{
    public delegate void OnSaveGame();
    public OnSaveGame onSaveGame;

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
        PlayerPrefs.SetFloat("playerShopRep", PlayerManager.instance.GetPlayerStat().shopReputaation);
        PlayerPrefs.SetInt("playerTotalDayShopOpen", PlayerManager.instance.GetPlayerStat().totalDaysShopIsOpen);
        PlayerPrefs.SetInt("playerTotalGold", PlayerManager.instance.GetPlayerStat().playerTotalGold);
    }
}
