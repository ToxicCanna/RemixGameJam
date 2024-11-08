using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] ShopManager shopManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.tag == "StatShop")
        {
            shopManager.EnableShop(0);
        }
        if (other.CompareTag("Player") && gameObject.tag == "KeyShop")
        {
            shopManager.EnableShop(1);
        }
    }
}
