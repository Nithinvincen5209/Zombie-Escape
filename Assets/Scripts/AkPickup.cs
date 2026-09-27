using UnityEngine;
using AK.Wwise;

public class AkPickup : MonoBehaviour
{
    
    bool canPickup = false;
    public Canvas PickupCanvas;
    public GameObject gunToEquip;
    public ParticleSystem muzzleFlash;
    public AK.Wwise.Event GunPickup;
    void Start()
    {
        

        PickupCanvas.enabled = false;
      
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPickup)
        {
            Debug.Log("F Key Pressed");
            muzzleFlash.Stop();
            AkSoundEngine.PostEvent("GunPickup",gameObject);
            GameObject Player = GameObject.FindGameObjectWithTag("Player");
            GunSwitcher gun = Player.GetComponent<GunSwitcher>();
            if (gun != null && gunToEquip != null)
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
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided with Ak Pickup");
            canPickup = true;
            PickupCanvas.enabled = true;
           
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exited Ak Pickup Area");
            canPickup = false;
            PickupCanvas.enabled = false;
        }
    }
}
