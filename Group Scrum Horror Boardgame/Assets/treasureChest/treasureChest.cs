using UnityEngine;

public class treasureChest : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private MeshFilter meshFilter;
    public Mesh openedChestMesh;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Treasure chest opened! You found some gold coins!");
            meshFilter.mesh = openedChestMesh;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the treasure chest area. Press 'E' to open it.");
            isPlayerInRange = true;
        }
    }
}
