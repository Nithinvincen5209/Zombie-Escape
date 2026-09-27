using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ZombieAi : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    public float detectionRange = 200f;
    public float attackRange = 30f;
    public Animator animator;
   bool canFollow = true;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       
        
    }

    void Update()
    {
        ZombieFollow();
    }
    void ZombieFollow()
    {
        if (!canFollow)
        {
            agent.ResetPath();
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
            return;
        }

            float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
            if (distance <= attackRange)
            {
                agent.ResetPath();
                animator.SetBool("Run", false);
                animator.SetBool("Attack", true);
               

            }
            else 
            {
                
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);


            }

           

        }
        else
        {
            agent.ResetPath();
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);

        }

    }
    public void  StopPlayerFollow()
    {
        canFollow = false;
        agent.ResetPath();
        animator.SetBool("Run", false);
        animator.SetBool("Attack", false);
    }
}
