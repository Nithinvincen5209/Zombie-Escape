using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;
    public int killCount = 0;
    public TextMeshProUGUI killCountText;
    public float streakWindow = 3f;
    private float StreakTimer = 0f;
    private int streakKills = 0;
    public StreakManager streakManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (StreakTimer > 0)
        {
            StreakTimer -= Time.deltaTime;
            if (StreakTimer <= 0)
            {
                streakKills = 0;
            }
        }
        
    }
    public void AddKill()
    {
        killCount++;
        UpdateKillCount();
        if(StreakTimer >0)
        {
            streakKills++;
            if (streakKills == 2 && streakManager != null)
            {
                streakManager.ShowDoubleStreak();
            }
        }
        else
        {
            streakKills = 1;
        }
        StreakTimer = streakWindow;
    }
    void UpdateKillCount()
    {
        if (killCountText != null)
        {
            killCountText.text =  killCount.ToString();
        }
    }

}
