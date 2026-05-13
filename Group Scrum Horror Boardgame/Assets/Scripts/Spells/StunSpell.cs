using UnityEngine;
using UnityEngine.AI;

public class StunSpell : MonoBehaviour
{
    
    private bool spellUsed = false;
    private float beamTimer = 1;
    [SerializeField] private GameObject stunBeam;
    [SerializeField] private GameObject ballEffects;

    [SerializeField] private float stunDuration = 3;
    public bool enemyHit = false;
    public GameObject enemy;
    public float originalSpeed;

    void Update()
    {
        useSpell();
        spellLogic();
    }

    private void useSpell()
    {
        if (transform.root.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !spellUsed)
        {
            spellUsed = true;
            stunBeam.SetActive(true);
        }
    }

    private void spellLogic()
    {
        //verlaagd de timer zodat de spell voor 1 seconde actief is
        if (spellUsed)
        {
            beamTimer -= Time.deltaTime;
        }

        if (beamTimer <= 0)
        {
            Destroy(ballEffects);
        }

        //controleert of de spell een vijand heeft geraakt, zo ja, dan wordt de snelheid van de vijand op 0 gezet en na de stunDuration weer teruggezet naar de originele snelheid
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
