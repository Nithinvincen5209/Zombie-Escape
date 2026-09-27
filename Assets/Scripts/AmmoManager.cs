using UnityEngine;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public int currentAmmo = 10;
    public int maxAmmo = 100;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI outOfAmmoText;

    public void AddAmmo(int amount)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + amount, 0, maxAmmo);
        UpdateAmmoUI();
        if(currentAmmo > 0 && outOfAmmoText != null)
        {
            outOfAmmoText.enabled = false;
        }
    }

    public bool UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            UpdateAmmoUI();
            return true;
        }
        return false;
    }

    public void UpdateAmmoUI()
    {
        if (ammoText != null)
            ammoText.text = currentAmmo.ToString();
    }

    public int GetAmmo()
    {
        return currentAmmo;
    }
}