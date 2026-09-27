using UnityEngine;
using AK.Wwise;

public class AkbulletPickup : MonoBehaviour
{
    public int ammoAmount = 30;
    public Animator pickupAnimator;
    public TMPro.TextMeshProUGUI BulletText;
    public TMPro.TextMeshProUGUI outofAmmo;
    private bool isPickedUp = false;
    public AK.Wwise.Event Play_AkReload;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GunSwitcher gun = other.GetComponent<GunSwitcher>();
            if(gun != null)
            {
                AmmoManager akAmmo = gun.ak47.GetComponent<AmmoManager>();
                if ((akAmmo != null))
                {
                    akAmmo.AddAmmo(ammoAmount);
                }
                if(gun.currentGun == gun.ak47)
                {
                    AkSoundEngine.PostEvent("Play_AkReload", gameObject);
                }
            }
            if(pickupAnimator != null && !isPickedUp)
            {
                pickupAnimator.SetBool("Reload", true);
                isPickedUp = true;

            }
            else if (pickupAnimator != null && isPickedUp)
            {
                isPickedUp = false;
                pickupAnimator.SetBool("Reload", false);
                
            }

                Destroy(gameObject, 1.5f);


        }
    }
}
