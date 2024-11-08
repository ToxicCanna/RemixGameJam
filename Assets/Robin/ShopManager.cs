using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    #region SerializedVariables
    [Header("Reference")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerHealth player1Health;
    [SerializeField] PlayerHealth player2Health;
    [SerializeField] GameObject powerUpShop;
    [SerializeField] GameObject keyShop;

    [Header("Text")]
    [SerializeField] private Text StatCostText;
    [SerializeField] private Text YKeyCostText;
    [SerializeField] private Text BKeyCostText;

    [Header("StatCost")]
    [SerializeField] public int cost;
    [SerializeField] private int costIncrement;
    [SerializeField] public int YKeyCost;
    [SerializeField] public int BKeyCost;

    [Header("IncrementValue")]
    [SerializeField] private int HPIncrement;
    [SerializeField] private int ATKIncrement;
    [SerializeField] private int DEFIncrement;
    #endregion

    #region Initialization
    private void Start()
    {
        powerUpShop.SetActive(false);
        keyShop.SetActive(false);
    }

    private void Update()
    {
        StatCostText.text = "Cost: $" + cost.ToString();
        YKeyCostText.text= "YKey ($" + YKeyCost.ToString() + ")";
        BKeyCostText.text = "BKey ($" + BKeyCost.ToString() + ")";
    }
    #endregion

    #region StatShop
    public void PurchaseHP()
    {
        if (cost <= playerStats.gold)
        {
            playerStats.PayGold(cost);
            player1Health.Heal(HPIncrement);
            player2Health.Heal(HPIncrement);
            Debug.Log("Player 1 HP is " + player1Health.health);
            Debug.Log("Player 2 HP is " + player2Health.health);
        }
        else
        {
            Debug.Log("Sorry, you don't have enough gold");
        }
    }

    public void PurchaseATK()
    {
        if (cost <= playerStats.gold)
        {
            playerStats.PayGold(cost);
            playerStats.attack += ATKIncrement;
            cost += costIncrement;
            Debug.Log("Player ATK is " + playerStats.attack);
        }
        else
        {
            Debug.Log("Sorry, you don't have enough gold");
        }
    }

    public void PurchaseDEF()
    {
        if (cost <= playerStats.gold)
        {
            playerStats.PayGold(cost);
            playerStats.defense += DEFIncrement;
            cost += costIncrement;
            Debug.Log("Player DEF is " + playerStats.defense);
        }
        else
        {
            Debug.Log("Sorry, you don't have enough gold");
        }
    }
    #endregion

    #region KeyShop
    public void PurchaseYKey()
    {
        if (YKeyCost <= playerStats.gold)
        {
            playerStats.PayGold(YKeyCost);
            playerStats.YKeys++;
            Debug.Log("You have " + playerStats.YKeys + " yellow keys");
        }
        else
        {
            Debug.Log("Sorry, you don't have enough gold");
        }
    }

    public void PurchaseBKey()
    {
        if (BKeyCost <= playerStats.gold)
        {
            playerStats.PayGold(BKeyCost);
            playerStats.BKeys++;
            Debug.Log("You have " + playerStats.BKeys + " blue keys");
        }
        else
        {
            Debug.Log("Sorry, you don't have enough gold");
        }
    }
    #endregion

    #region ExitShop
    public void ExitPowerUpShop()
    {
        powerUpShop.SetActive(false);
    }

    public void ExitKeyShop()
    {
        keyShop.SetActive(false);
    }
    #endregion
}
