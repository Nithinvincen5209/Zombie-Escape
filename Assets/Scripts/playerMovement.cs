using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    public Animator AkAnimator;
    public GameObject StartCanvas;
    
    void Start()
    {
        
        StartCoroutine(DisableCanvas());
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");

        Vector3 horizontalMove = transform.right * movex + transform.forward * movez;
        controller.Move(horizontalMove * speed * Time.deltaTime);

        bool isMoving = horizontalMove.magnitude > 0.1f;
        AkAnimator.SetBool("Walk", isMoving);
        if(isMoving)
        {
            CheckSurfaceBelow();
        }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            AkSoundEngine.PostEvent("Stop_Player_Footstep", gameObject);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) )
        {
            AkSoundEngine.PostEvent("Play_Player_Footstep", gameObject);
        }
        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)  )
        {
            AkSoundEngine.PostEvent("Stop_Player_Footstep", gameObject);
        } 


    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null) return;
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("WoodPlane"))
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Jumping on wood plane");
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            else
            {
                Debug.Log("Standing on wood plane");
            }
            
            
        }
    }
    void CheckSurfaceBelow()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, 1f))
        {
            if (hit.collider.CompareTag("Concrete"))
            {
                AkSoundEngine.SetSwitch("Footstep", "Concrete", gameObject);
            }
            else if (hit.collider.CompareTag("WoodPlane"))
            {
                AkSoundEngine.SetSwitch("Footstep", "Wood", gameObject);
            }
            else if (hit.collider.CompareTag("Grass"))
            {
                AkSoundEngine.SetSwitch("Footstep", "Grass", gameObject);
            }
        }
    }
    IEnumerator DisableCanvas()
    {
        StartCanvas.SetActive(true);
        yield return  new WaitForSeconds(8);
        Destroy(StartCanvas);

    }
}
