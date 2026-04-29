using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Ai_script : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject[] target;
    public GameObject[] teleportlocation;
    private Inventory inventory;

    public Transform player;
    public float detectionRange = 10f;
    public float fieldOfView = 60f;
    public float stopDistance = 3f;

    public float normalSpeed = 3.5f;
    public float chaseSpeed = 8f;
    public float reactionDelay = 1f;

    private bool isChasing = false;
    private bool isWaiting = false;
    private bool playerDetected = false;

    void Start()
    {
        GoToRandomTarget();

        inventory = player.GetComponent<Inventory>();
        navMeshAgent.speed = normalSpeed;
    }

    void Update()
    {
        DetectPlayer();

        if (playerDetected && isChasing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stopDistance)
            {
                navMeshAgent.SetDestination(player.position);
            }
            else
            {
                navMeshAgent.ResetPath();
            }
        }
        else if (!isWaiting)
        {
            navMeshAgent.speed = normalSpeed;

            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                GoToRandomTarget();
            }
        }

        // 🔁 Reset chase als speler weg is
        if (!playerDetected && isChasing)
        {
            isChasing = false;
            navMeshAgent.speed = normalSpeed;
        }
    }

    IEnumerator StartChase()
    {
        isWaiting = true;

        navMeshAgent.ResetPath();
        navMeshAgent.speed = 0f;

        yield return new WaitForSeconds(reactionDelay);

        isChasing = true;
        isWaiting = false;
        playerDetected = true;

        navMeshAgent.speed = chaseSpeed;
    }

    void DetectPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < fieldOfView / 2f)
            {
                Ray ray = new Ray(transform.position + Vector3.up, directionToPlayer);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, detectionRange))
                {
                    if (hit.transform == player)
                    {
                        playerDetected = true; // ✅ meteen zetten

                        if (!isChasing && !isWaiting)
                        {
                            StartCoroutine(StartChase());
                        }

                        Debug.DrawRay(ray.origin, ray.direction * detectionRange, Color.red);
                        return;
                    }
                }
            }
        }

        playerDetected = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == player)
        {
            OnPlayerTouch();
        }
    }

    void GoToRandomTarget()
    {
        int index = Random.Range(0, target.Length);
        navMeshAgent.SetDestination(target[index].transform.position);
    }

    void OnPlayerTouch()
    {
        Debug.Log("Speler aangeraakt");

        int index = Random.Range(0, teleportlocation.Length);
        player.position = teleportlocation[index].transform.position;

        float aftrekking = inventory.coinsHeld * 0.9f;
        inventory.coinsHeld = Mathf.RoundToInt(aftrekking);

        Debug.Log(inventory.coinsHeld);
    }
}