using UnityEngine;

public class TorchDetector : MonoBehaviour
{
    public float detectionRadius = 2f;
    public LayerMask torchLayer;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            detectionRadius,
            torchLayer
        );

        foreach (Collider hit in hits)
        {
            if (hit.gameObject.name == "torch")
            {
                Debug.Log("Torch nearby!");
                return;
            }
        }
    }
}