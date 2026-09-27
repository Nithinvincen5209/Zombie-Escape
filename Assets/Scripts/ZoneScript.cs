using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    public TextMeshProUGUI zoneText;
    public TMPro.TextMeshProUGUI winnerText;
    public GameObject door;
    public GameObject villaZombie;
    


    void Start()
    {
        zoneText.enabled = false;
        winnerText.enabled = false;
        door.SetActive(false);
        villaZombie.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered the zone");
            door.SetActive(true);
            villaZombie.SetActive(false);
            StartCoroutine(SafeZone());
       

        }
        
    }
    
    IEnumerator SafeZone()
    {
        zoneText.enabled = true;
        yield return new WaitForSeconds(3f);
        winnerText.enabled = true;
        Destroy(zoneText);

    }
    
}
