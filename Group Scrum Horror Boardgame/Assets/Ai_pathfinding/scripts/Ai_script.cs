using UnityEngine;
using UnityEngine.AI;

public class Ai_script : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject[] target;

    public Transform player;          // speler referentie
    public float detectionRange = 10f;
    public float fieldOfView = 60f;
    public float stopDistance = 3f;

    private bool playerDetected = false;

    void Start()
    {
        GoToRandomTarget();
    }

    void Update()
    {
        DetectPlayer();

        if (playerDetected)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stopDistance)
            {
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                navMeshAgent.ResetPath(); // stopt bewegen
            }
        }
        else
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                GoToRandomTarget();
            }
        }
    }

    void GoToRandomTarget()
    {
        int index = Random.Range(0, target.Length);
        navMeshAgent.SetDestination(target[index].transform.position);
    }

    void DetectPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check distance
        if (distanceToPlayer < detectionRange)
        {
            // Check field of view
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < fieldOfView / 2f)
            {
                Ray ray = new Ray(transform.position + Vector3.up, directionToPlayer);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, detectionRange))
                {
                    if (hit.transform == player)
                    {
                        playerDetected = true;
                        Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.red);
                        return;
                    }
                }
            }
        }

        playerDetected = false;
    }
}
