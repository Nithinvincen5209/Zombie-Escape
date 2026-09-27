using UnityEditor;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    
    public Canvas PickupCanvas;
    private bool canPickup = false;
    public GameObject gunToEquip;
    public AK.Wwise.Event gunPickup;

    void Start()
    {
        
        PickupCanvas.enabled = false;
    }

    void Update()
    {
        if(canPickup && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F Key Pressed");
            
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            AkSoundEngine.PostEvent("GunPickup", gameObject);
            GunSwitcher gun = player.GetComponent<GunSwitcher>();
            if(gun != null && gunToEquip != null)
            {
                gun.EquipGun(gunToEquip);
                gun.MarkGunCollected(gunToEquip);
            }
            PickupCanvas.enabled = false;
            gameObject.SetActive(false); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Gun Pickup");
            PickupCanvas.enabled = true;
            canPickup = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exited Gun Pickup Area");
            PickupCanvas.enabled = false;
            canPickup = false;
        }
    }
}
