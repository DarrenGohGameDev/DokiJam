using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private BasePotionStatScriptableObject potionStat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BasePotionStatScriptableObject GetPotionStat()
    {
        return potionStat;
    }
}