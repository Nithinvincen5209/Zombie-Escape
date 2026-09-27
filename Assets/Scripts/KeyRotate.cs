using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    public float rotationSpeed = 50f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
