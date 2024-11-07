using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    #region Variables
    [Header("Battle Stats")]
    [SerializeField] public int attack;
    [SerializeField] public int defense;

    [Header("Store Stats")]
    [SerializeField] public int gold;

    [Header("Keys")]
    [SerializeField] public int YKeys;
    [SerializeField] public int RKeys;
    [SerializeField] public int BKeys;
    #endregion

    #region Upgrades
    public void UpAtk(int amount)
    {
        attack += amount;
    }
    public void UpDef(int amount)
    {
        defense += amount;
    }
    #endregion

    #region Store
    public void AddGold(int amount)
    {
        gold += amount;
    }
    public void PayGold(int amount)
    {
        gold -= amount;
    }
    #endregion

    #region KeyStorage
    public enum KeyColor { Yellow, Red, Blue }

    public void AddKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Yellow:
                YKeys++;
                break;
            case KeyColor.Red:
                RKeys++;
                break;
            case KeyColor.Blue:
                BKeys++;
                break;
        }
    }

    public bool CanPay(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Yellow:
                if (YKeys > 0)
                {
                    YKeys--;
                    return true;
                }
                break;
            case KeyColor.Red:
                if (RKeys > 0)
                {
                    RKeys--;
                    return true;
                }
                break;
            case KeyColor.Blue:
                if (BKeys > 0)
                {
                    BKeys--;
                    return true;
                }
                break;
        }
        return false;
    }
    #endregion
}
