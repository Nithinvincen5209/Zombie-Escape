using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject pistol;
    public GameObject ak47;

    public GameObject currentGun;
    private bool pistolCollected = false;
    private bool ak47Collected = false;
    

    void Start()
    {
        pistol.SetActive(false);
        ak47.SetActive(false);
        currentGun = null;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1) && pistolCollected && ak47Collected)
        {
            GunSwitch();
            

        }
    }

    public void EquipGun(GameObject gunToEquip)
    {
        if (currentGun != null)
        {
           AkGunshot akgun= currentGun.GetComponent<AkGunshot>();
            if(akgun != null)
            {
                akgun.StopSound();
            }

            currentGun.SetActive(false);
        }

        gunToEquip.SetActive(true);
        currentGun = gunToEquip;

        // Update UI for the equipped gun
        AmmoManager ammo = currentGun.GetComponent<AmmoManager>();
        if (ammo != null)
        {
            ammo.UpdateAmmoUI();
        }

        Debug.Log("Equipped: " + gunToEquip.name);
    }

    public void GunSwitch()
    {
        if (currentGun == pistol)
            EquipGun(ak47);
        
        else
            EquipGun(pistol);
    }
    public void MarkGunCollected(GameObject gun)
    {
        if(gun == pistol)
        {
            pistolCollected = true;
        }
        else if(gun == ak47)
        {
            ak47Collected = true;
        }
    }

    public AmmoManager GetCurrentAmmoManager()
    {
        return currentGun != null ? currentGun.GetComponent<AmmoManager>() : null;
    }
}