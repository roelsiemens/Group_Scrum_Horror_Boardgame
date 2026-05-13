using UnityEngine;
using UnityEngine.AI;

public class StunSpell : MonoBehaviour
{
    
    private bool spellUsed = false;
    private float beamTimer = 1;
    [SerializeField] private GameObject stunBeam;
    [SerializeField] private GameObject ballEffects;

    public float stunDuration = 3;
    public bool enemyHit = false;
    public GameObject enemy;
    public float originalSpeed;

    void Update()
    {
        if (transform.root.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !spellUsed)
        {
            spellUsed = true;
            stunBeam.SetActive(true);
        }

        if (spellUsed)
        {
            beamTimer -= Time.deltaTime;
        }

        if (beamTimer <= 0)
        {
            Destroy(ballEffects);
        }

        if (enemyHit)
        {
            enemyHit = false;
            enemy.GetComponent<NavMeshAgent>().speed = 0;
            Invoke("ResetEnemySpeed", stunDuration);
        }
    }

    private void ResetEnemySpeed()
    {
        enemy.GetComponent<NavMeshAgent>().speed = originalSpeed;
    }
}
