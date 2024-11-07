using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerStats.KeyColor requiredKeyColor;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TryUnlockDoor();
        }
    }

    private void TryUnlockDoor()
    {
        if (PlayerStats.Instance.CanPay(requiredKeyColor))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log($"You need a {requiredKeyColor} key to open this door.");
        }
    }

    private void OpenDoor()
    {
        if (PlayerStats.Instance.CanPay(requiredKeyColor))
        {
            Debug.Log($"{requiredKeyColor} door opened and key consumed!");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"You need a {requiredKeyColor} key to open this door.");
        }
    }
}
