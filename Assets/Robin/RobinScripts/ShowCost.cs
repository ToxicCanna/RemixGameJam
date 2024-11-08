using UnityEngine;
using UnityEngine.UI;

public class ShowCost : MonoBehaviour
{
    private ShopManager shopManager;
    [SerializeField] private Text showCost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showCost.text = shopManager.cost.ToString();
    }
}
