using UnityEngine;
using AK.Wwise;

public class GunShoot : MonoBehaviour
{
   public Camera playerCamera;
   public float ShootRange = 50f;
   public int MaxAmmo = 10;
    public float damage = 2f;
    public Animator gunAnimator;
    public GameObject HitEffect;
    public GameObject defaultEffect;
    public Transform hiteffectParent;
    public TMPro.TextMeshProUGUI ammoText;
    public AmmoManager ammoManager;
    public ParticleSystem muzzleFlash;
    public AK.Wwise.Event Play_Pistol_Shot;
    void Start()
    {
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        muzzleFlash.Stop();
        ammoText.enabled = false;
    }

   
    void Update()
    {
        if(Input.GetMouseButtonDown(0) )
        {
            if (ammoManager.UseAmmo())
            {
                Shoot();
                if (muzzleFlash != null)
                {
                    muzzleFlash.Play();
                }
                gunAnimator.SetBool("Fire", true);
                gunAnimator.SetBool("Reload", false);

                AkSoundEngine.PostEvent("Play_Pistol_Shot", gameObject);

            }
            else
            {
                Debug.Log("No Ammo Left!");
                ammoText.enabled = true;
            }
           
        }
        if(Input.GetMouseButtonUp(0))
        {
            if (muzzleFlash != null)
            {
                muzzleFlash.Stop();
            }
            gunAnimator.SetBool("Fire", false);
            
        }

    }
    void Shoot()
    {
        
        
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,ShootRange))
        {
            GameObject effectToPlay = null;
            Debug.Log("Hit:" + hit.collider.name);
            if(hit.collider.CompareTag("Enemy"))
            {
                effectToPlay = HitEffect;
                EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Enemy Hit: " + enemy.name + " Damage: " + damage);
                }
            }
            else
            {
                effectToPlay = defaultEffect;
            }
            if (effectToPlay != null)
            {
                GameObject hitEffect = Instantiate(effectToPlay, hit.point, Quaternion.LookRotation(hit.normal));
                if (hiteffectParent != null)
                {
                    hitEffect.transform.SetParent(hiteffectParent);
                    Destroy(hitEffect, 2f);
                }
            }
        }
      
    }
}
