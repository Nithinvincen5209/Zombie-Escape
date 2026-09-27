using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 14f;
    public float maxHealth = 14f;
    public Animator dieAnimator;
    private bool isDead = false;
    public Image healthbarFill;
    public Canvas healthbarCanvas;
    public AK.Wwise.Event Play_Zombie_Damage;

    private void Start()
    {
        healthbarCanvas.enabled = true;
        health = maxHealth;
        UpdateHealthBar();
    }
    public void TakeDamage(float amount)
    {
        if (isDead) return;

        health -= amount;
        Debug.Log("Enemy Health: " + health);
        UpdateHealthBar();
        if (health <= 0f)
        {
           
         isDead = true;
            healthbarCanvas.enabled = false;
            StartCoroutine(die());

        }
    }
    void UpdateHealthBar()
    {
        if(healthbarFill != null)
        {
            healthbarFill.fillAmount = health / maxHealth;
        }
    }
     IEnumerator  die()
    {
        Debug.Log("Enemy Died: " + gameObject.name);
        if(dieAnimator != null)
        {
            dieAnimator.SetBool("Die", true);
            Play_Zombie_Damage.Post(gameObject);
        }
        if(KillCounter.instance != null)
        {
            KillCounter.instance.AddKill();
        }
        yield return new WaitForSeconds(2.3f);
        Destroy(gameObject);
    }
}
