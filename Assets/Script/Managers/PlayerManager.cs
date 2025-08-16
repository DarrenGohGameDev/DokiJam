using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] private PlayerStat playerStat;

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

    public PlayerStat GetPlayerStat()
    {
        return playerStat;
    }
}
