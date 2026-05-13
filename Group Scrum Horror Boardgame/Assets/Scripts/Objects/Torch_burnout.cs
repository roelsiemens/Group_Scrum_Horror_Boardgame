using UnityEngine;

public class Torch_burnout : MonoBehaviour
{
    private float burnTime = 45f;
    private Collider torchCollider;
    [SerializeField] private GameObject torchLight;
    [SerializeField] private GameObject torchParticle;

    private void Update()
    {
        torchCollider = GetComponent<Collider>();
        BurnOut();
    }

    //laat een timer aftellen wanneer de speler de torch vasthoudt, wanneer de timer op 0 staat worden de light en particle system verwijderd
    private void BurnOut()
    {
        
        if (!torchCollider.enabled && burnTime > 0)
        {
            burnTime -= Time.deltaTime;
        }

        if (burnTime <= 0f)
        {
            Destroy(torchLight);
            Destroy(torchParticle);
        }
    }
}
