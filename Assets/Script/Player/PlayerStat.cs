using UnityEngine;

[CreateAssetMenu(fileName = "BasePlayerStat", menuName = "ScriptableObjects/BasePlayerStat")]
public class PlayerStat : ScriptableObject
{
	//   - player reputation
	//- player how many day the shop have been open
	//- player gold
	//- player potion material stock
	//- player potion stock
	public float shopReputaation;
	public int totalDaysShopIsOpen;
	public int playerTotalGold;

}
