using System.Collections;
using TMPro;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public int keyCount = 0;
    public TextMeshProUGUI keyCounterText;
    public GameObject key;
    public TextMeshProUGUI keyamount;
    public TextMeshProUGUI keyColletText;
    public GameObject ShockEffect;
    public TextMeshProUGUI shockerText;
    void Start()
    {
        UpdateKeyUI();
        key.SetActive(false);
        keyamount.gameObject.SetActive(false);
        keyColletText.gameObject.SetActive(false);
        shockerText.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }
    public void CollectKey()
    {
        keyCount++;
        UpdateKeyUI();
        if(keyCount == 1)
        {
            key.SetActive(true);
            keyamount.gameObject.SetActive(true);
        }
        if(keyColletText != null)
        {
            StartCoroutine(ShowKeyText());
        }
        if(keyCount == 5 && ShockEffect != null)
        {
            ShockEffect.SetActive(false);
            StartCoroutine(EnableShockerText());
        }
        
    }
    IEnumerator ShowKeyText()
    {
        keyColletText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        keyColletText.gameObject.SetActive(false);
    }
    void UpdateKeyUI()
    {
        keyCounterText.text = keyCount.ToString();
    }
    IEnumerator EnableShockerText()
    {
        shockerText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        shockerText.gameObject.SetActive(false);
    }
    
}
