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
    public bool CanPayYellow()
    {
        if (YKeys > 0)
        {
            YKeys--;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CanPayRed()
    {
        if (RKeys > 0)
        {
            RKeys--;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CanPayBlue()
    {
        if (BKeys > 0)
        {   
            BKeys--;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void AddYellow()
    {
        YKeys++;
    }
    public void AddRed()
    {
        RKeys++;
    }
    public void AddBlue()
    {
        BKeys++;
    }
    #endregion
}
