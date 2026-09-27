using UnityEngine;

public class StopIntroMusic : MonoBehaviour
{
    public AK.Wwise.Event Stop_Intro;
    void Start()
    {
        Time.timeScale = 1f;
        Stop_Intro.Post(gameObject);
    }

    
    void Update()
    {
        
    }
}
