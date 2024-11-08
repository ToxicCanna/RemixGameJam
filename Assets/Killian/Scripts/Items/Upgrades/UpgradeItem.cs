using UnityEngine;

public class UpgradeItem : MonoBehaviour, ICollect
{
    public AtkDefUpgradeSO upgradeData;

    public void Collect()
    {
        if (PlayerStats.Instance != null)
        {
            if (upgradeData.attackBonus > 0)
            {
                PlayerStats.Instance.UpAtk(upgradeData.attackBonus);
                Debug.Log($"Minor/Major Attack Upgrade Collected! +{upgradeData.attackBonus} Attack");
            }
            if (upgradeData.defenseBonus > 0)
            {
                PlayerStats.Instance.UpDef(upgradeData.defenseBonus);
                Debug.Log($"Minor/Major Defense Upgrade Collected! +{upgradeData.defenseBonus} Defense");
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}