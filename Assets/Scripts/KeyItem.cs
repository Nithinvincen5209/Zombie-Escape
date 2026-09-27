using System.Collections;
using TMPro;
using UnityEngine;

public class KeyItem : MonoBehaviour
{

    public AK.Wwise.Event Key;
    void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Key collected by player.");
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            if (keyCollector != null)
            {
                keyCollector.CollectKey();
                AkSoundEngine.PostEvent("Key", gameObject);
            }
            Destroy(gameObject);
        }
    }
    
}
