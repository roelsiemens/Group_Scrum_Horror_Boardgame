using UnityEngine;

public class Torch_burnout : MonoBehaviour
{
    [SerializeField] private float burnTime = 45f;
    private Collider torchCollider;
    [SerializeField] private GameObject torchLight;
    [SerializeField] private GameObject torchParticle;

    private void Update()
    {
        torchCollider = GetComponent<Collider>();
        BurnOut();
    }

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
