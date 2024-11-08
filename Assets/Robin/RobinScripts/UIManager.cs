using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameObject hud;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] PlayerHealth player1Health;
    [SerializeField] PlayerHealth player2Health;

    [Header("Player HUD")]
    [SerializeField] private Text HP1;
    [SerializeField] private Text HP2;

    [SerializeField] private Text atk;
    [SerializeField] private Text def;
    [SerializeField] private Text gold;

    [SerializeField] private Text yKey;
    [SerializeField] private Text bKey;
    [SerializeField] private Text rKey;

    private void Start()
    {
        hud.SetActive(false);
    }
    private void Update()
    {
        EnableHUD();
        
        //Player Health
        HP1.text = player1Health.health.ToString();
        HP2.text = player2Health.health.ToString();

        //Player Stats
        atk.text = playerStats.attack.ToString();
        def.text = playerStats.defense.ToString();
        gold.text = playerStats.gold.ToString();

        //Player Keys
        yKey.text = playerStats.YKeys.ToString();
        bKey.text = playerStats.BKeys.ToString();
        rKey.text = playerStats.RKeys.ToString();
    }
    private void EnableHUD()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (hud.activeInHierarchy == true)
            {
                hud.SetActive(false);
            }
            else
            {
                hud.SetActive(true);
            }
            
        }
    }
}
