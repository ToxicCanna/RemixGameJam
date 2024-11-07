using UnityEngine;

[CreateAssetMenu(fileName = "New Attack/Defense Upgrade", menuName = "Scriptable Objects/AtkDefUpgradeSO")]
public class AtkDefUpgradeSO : ScriptableObject
{
    public enum UpgradeType { Minor, Major }
    public UpgradeType upgradeType;
    public int attackBonus;
    public int defenseBonus;
}