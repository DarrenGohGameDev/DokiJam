using UnityEngine;

public class ReputationManager : MonoBehaviour
{
    public delegate void OnShopReputationChange(float rep);
    public OnShopReputationChange onShopReputationChange;

    private void OnEnable()
    {
        onShopReputationChange += SetShopReputation;
    }

    private void OnDisable()
    {
        onShopReputationChange -= SetShopReputation;
    }

    private void SetShopReputation(float rep)
    {
        PlayerManager.instance.GetPlayerStat().shopReputaation += rep;
    }
}