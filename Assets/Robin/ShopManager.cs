using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("Cost")]
    [SerializeField] public int cost;
    [SerializeField] private int costIncrement;
    [SerializeField] private Text costText;

    [Header("Reference")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerHealth player1Health;
    [SerializeField] PlayerHealth player2Health;
    [SerializeField] GameObject Shop;

    [Header("IncrementValue")]
    [SerializeField] private int HPIncrement;
    [SerializeField] private int ATKIncrement;
    [SerializeField] private int DEFIncrement;

    private void Update()
    {
        costText.text = "Cost: $" + cost.ToString();
    }
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

    public void ExitShop()
    {
        Shop.SetActive(false);
    }
}
