using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    private float currentHealth;
    public Image healthbarFill;
    public Canvas deadCanvas;
    private bool isDead = false;
    public AK.Wwise.Event Play_Player_Grunt;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBarUI();
        if (deadCanvas != null)
        {
            deadCanvas.enabled = false; 
        }
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;
        currentHealth -= amount;
        Play_Player_Grunt.Post(gameObject);
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBarUI();
        if (currentHealth <= 0f)
        {
            Die();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
        }
    } 
     private void UpdateHealthBarUI()
    {
        if (healthbarFill != null)
        {
            healthbarFill.fillAmount = currentHealth / maxHealth;
        }
    }
    private void Die()
    {
        isDead = true;
        Debug.Log("Player Died: " + gameObject.name);
        if (deadCanvas != null)
        {
            deadCanvas.enabled = true; 
        }
    }
    public void Heal(float amount)
    {
                if (isDead) return;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBarUI();
    }
}
