using UnityEngine;
using AK.Wwise;

public class bulletPickup : MonoBehaviour
{
    public int ammoAmount = 20;
    public Animator pickupAnimator;
    public AK.Wwise.Event Play_PistolReload;
    
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GunSwitcher gun = other.GetComponent<GunSwitcher>();
            if (gun != null)
            {
                AmmoManager pistolammo = gun.pistol.GetComponent<AmmoManager>();
                if (pistolammo != null)
                {
                    pistolammo.AddAmmo(ammoAmount);

                }

            }
            if (gun.currentGun == gun.pistol)
            {

                AkSoundEngine.PostEvent("Play_PistolReload", gameObject);

                if (pickupAnimator != null)
                {
                    pickupAnimator.SetBool("Reload", true);


                }
                Destroy(gameObject, 0.5f);
            }
        }
       

    }
}
