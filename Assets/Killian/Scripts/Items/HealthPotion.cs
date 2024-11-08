using UnityEngine;

public class HealthPotion : MonoBehaviour, ICollect
{
    public enum PotionType { Minor, Major }
    public PotionType potionType;
    public int restoreAmount;

    public void Collect()
    {
        Debug.Log(potionType + " health potion collected");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log($"Before healing: Player Health = {playerHealth.health}");

                playerHealth.Heal(restoreAmount);

                Debug.Log($"After healing: Player Health = {playerHealth.health}");

                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on the player!");
            }
        }
    }
}
