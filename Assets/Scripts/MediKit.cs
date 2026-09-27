using UnityEngine;

public class MediKit : MonoBehaviour
{
    public float healAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if(health != null)
            {
                health.Heal(healAmount);

                Destroy(gameObject); 
            }
        }
    }
}
