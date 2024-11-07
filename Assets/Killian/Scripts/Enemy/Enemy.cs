using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemySO enemyData;

    private int currentHealth;
    private bool isCombatActive = false;

    private PlayerHealth playerHealth;

    private void Start()
    {
        currentHealth = enemyData.health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCombatActive)
        {
            isCombatActive = true;
            playerHealth = other.GetComponent<PlayerHealth>();
            Debug.Log($"{enemyData.enemyName} has encountered the player!");

            StartCombat();
        }
    }

    private void StartCombat()
    {
        StartCoroutine(CombatTurns());
    }

    private IEnumerator CombatTurns()
    {
        while (currentHealth > 0 && playerHealth.health > 0)
        {
            int damageToPlayer = Mathf.Clamp(enemyData.attack - PlayerStats.Instance.defense, 1, 1000);
            playerHealth.Damage(damageToPlayer);
            Debug.Log($"{enemyData.enemyName} dealt {damageToPlayer} damage to the player. Player health: {playerHealth.health}");

            if (playerHealth.health <= 0)
            {
                Debug.Log("Player has been defeated!");
                playerHealth.Death();
                Die();
                yield break;
            }
            int damageToEnemy = Mathf.Clamp(PlayerStats.Instance.attack - enemyData.defense, 1, 1000);
            currentHealth -= damageToEnemy;
            Debug.Log($"Player dealt {damageToEnemy} damage to {enemyData.enemyName}. Enemy health: {currentHealth}");

            if (currentHealth <= 0)
            {
                Die();
                yield break;
            }
            yield return null;
        }
    }

    private void Die()
    {
        Debug.Log($"{enemyData.enemyName} has been defeated!");
        DropGold();
        Destroy(gameObject);
    }

    private void DropGold()
    {
        PlayerStats.Instance.AddGold(enemyData.gold);
        Debug.Log($"Dropped {enemyData.gold} gold.");
    }
}