using UnityEngine;
using UnityEngine.AI;

public class StunSpellTrigger : MonoBehaviour
{
    private StunSpell stunSpell;

    private void Start()
    {
        stunSpell = GetComponentInParent<StunSpell>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //zet variables in de StunSpell script wanneer de enemy geraakt is door de spell
        if (other.CompareTag("Enemy"))
        {
            stunSpell.enemy = other.gameObject;
            stunSpell.originalSpeed = stunSpell.enemy.GetComponent<NavMeshAgent>().speed;
            stunSpell.enemyHit = true;
        }
    }
}
