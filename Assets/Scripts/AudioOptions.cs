using UnityEngine;
using UnityEngine.UI;

public class AudioOptions : MonoBehaviour
{
    public Scrollbar sfxScrollbar;
    public Scrollbar musicScrollbar;
    void Start()
    {
        float SavedValue = PlayerPrefs.GetFloat("SfxVolume", 1f);
        sfxScrollbar.value = SavedValue;
        AkSoundEngine.SetRTPCValue("Sfx_Handler", SavedValue * 100f);
        sfxScrollbar.onValueChanged.AddListener(SetSfxVolume);

        float SavedMusicValue = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicScrollbar.value = SavedMusicValue;
        AkSoundEngine.SetRTPCValue("Music_Handler", SavedMusicValue * 100f);
        musicScrollbar.onValueChanged.AddListener(SetMusicVolume);
    }

    
    void Update()
    {
        
    }
    public void SetSfxVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("Sfx_Handler", value * 100f);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        AkSoundEngine.SetRTPCValue("Music_Handler", value * 100f);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
}
