using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public Canvas gameoverCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameoverCanvas.enabled = true; 
        }
    }
}
