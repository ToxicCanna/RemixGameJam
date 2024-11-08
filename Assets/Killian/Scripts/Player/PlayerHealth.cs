using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int health;

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    public void Damage(int amount)
    {
        health -= Mathf.Max(amount, 0);
        health = Mathf.Max(health, 0);
    }
    public void Heal(int amount)
    {
        health += amount;
    }

    public void Death()
    {
        //you just lost the game. WOMP WOMP
        Debug.Log("Player has died.");

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.SetDead();
        }

        StartCoroutine(WaitAndLoadMainMenu());
    }

    private IEnumerator WaitAndLoadMainMenu()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
