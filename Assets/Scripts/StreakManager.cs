using System.Collections;
using TMPro;
using UnityEngine;
using  AK.Wwise;

public class StreakManager : MonoBehaviour
{
    public static StreakManager instance;
    public TextMeshProUGUI streakText;
    public float displayDuration = 1.5f;
    public AK.Wwise.Event Play_Double_Streak;
    
    void Awake()
    {
        instance = this;
        streakText.gameObject.SetActive(false);
    }
    public void ShowDoubleStreak()
    {
        StartCoroutine(FlashStreak());
        AkSoundEngine.PostEvent("Play_Double_Streak", gameObject);
    }
    IEnumerator FlashStreak()
    {
        streakText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        streakText.gameObject.SetActive(false);
    }
}
