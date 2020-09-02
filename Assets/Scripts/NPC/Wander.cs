using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;
    public Vector3 newPos;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private Animator animator;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            animator.SetBool("Moving", true);
            timer = 0;
        }

        //We have time left
        else
        {
            //We arrived
            if (transform.position == newPos)
            {
                animator.SetBool("Moving", false);
            }

        }




    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}