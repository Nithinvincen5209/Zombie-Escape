using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsOptions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown graphicsDropdown;
    void Start()
    {
      int savedQuality = PlayerPrefs.GetInt("GraphicsQuality", 2); 
        graphicsDropdown.value = savedQuality;
        QualitySettings.SetQualityLevel(savedQuality);
        
        graphicsDropdown.onValueChanged.AddListener(SetGraphicsQuality);
    }

   
    void Update()
    {
        
    }
    public void SetGraphicsQuality(int Index)
    {
        QualitySettings.SetQualityLevel(Index , true);
        PlayerPrefs.SetInt("GraphicsQuality", Index);

    }
}
