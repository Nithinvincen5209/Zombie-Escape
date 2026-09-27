using UnityEngine;

public class ShockTrigger : MonoBehaviour
{
    public AK.Wwise.Event Play_Electric_Shock;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered shock trigger");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(2);
                Play_Electric_Shock.Post(gameObject);
            }
        }
    }
}
