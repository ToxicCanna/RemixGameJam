using UnityEngine;
using static PlayerStats;

public class KeyScript : MonoBehaviour, ICollect
{
    public PlayerStats.KeyColor keyColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collided with {other.tag}");
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
        PlayerStats.Instance.AddKey(keyColor);

        Debug.Log($"{keyColor} key collected!");

        gameObject.SetActive(false);
    }
}
