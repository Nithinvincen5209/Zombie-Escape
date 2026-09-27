using UnityEngine;
using AK.Wwise;

public class AkGunshot : MonoBehaviour
{
    public Camera playerCamera;
    public float ShootRange = 50f;
    public int MaxAmmo = 10;
    public float damage = 2f;
    public GameObject HitEffect;
    public GameObject defaultEffect;
    public Transform hiteffectParent;
    public TMPro.TextMeshProUGUI ammoText;
    public AmmoManager ammoManager;
    public Animator AKAnimator;
    public float fireRate = 0.1f;
    private float nextFireTime = 0f;
    public ParticleSystem muzzleFlash;
    public AK.Wwise.Event Play_Akm_Shot;
    public AK.Wwise.Event Stop_Akm_Shot;
    void Start()
    {

        ammoText.enabled = false;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        muzzleFlash.Stop();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AkSoundEngine.PostEvent("Play_Akm_Shot", gameObject);
        }
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {

            if (ammoManager.UseAmmo())
            {
                nextFireTime = Time.time + fireRate;
                Shoot();
                if (muzzleFlash != null)
                {
                    muzzleFlash.Play();
                }
                AKAnimator.SetBool("Fire", true);
                AKAnimator.SetBool("Reload", false);


            }
            else
            {
                Debug.Log("No Ammo Left!");
                ammoText.enabled = true;
                AKAnimator.SetBool("Fire", false);
                muzzleFlash.Stop();
                AkSoundEngine.PostEvent("Stop_Akm_Shot", gameObject);
            }

        }
        if (Input.GetMouseButtonUp(0))
        {

            AKAnimator.SetBool("Fire", false);
            AkSoundEngine.PostEvent("Stop_Akm_Shot", gameObject);
        }

    }
    void Shoot()
    {


        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, ShootRange))
        {
            GameObject effectToPlay = null;
            Debug.Log("Hit:" + hit.collider.name);
            if (hit.collider.CompareTag("Enemy"))
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
    public void StopSound()
    {
        AkSoundEngine.PostEvent("Stop_Akm_Shot", gameObject);
        AKAnimator.SetBool("Fire", false);
        if (muzzleFlash != null)
        {
            muzzleFlash.Stop();
        }
    }
}
