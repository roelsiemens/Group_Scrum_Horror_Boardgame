using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Ai_script : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject[] target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GoToRandomTarget();
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            GoToRandomTarget();
        }
    }

    void GoToRandomTarget()
    {
        int index = Random.Range(0, target.Length);
        navMeshAgent.SetDestination(target[index].transform.position);
    }
}
