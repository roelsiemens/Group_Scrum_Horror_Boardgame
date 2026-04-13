using UnityEngine;

public class Altar : MonoBehaviour
{
    private Inventory playerInventory;

    public int coinsRequired = 1000;
    private int startingCoinsRequired;

    private bool inRange = false;

    private float maxY = 0f;
    private float minY = -1.01f;

    private float moveSpeed = 1f;

    private void Start()
    {
        startingCoinsRequired = coinsRequired;
    }

    private void Update()
    {
        float progress = 1f - (float)coinsRequired / startingCoinsRequired;

        float targetY = Mathf.Lerp(maxY, minY, progress);

        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = pos;

        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            coinsRequired -= playerInventory.coinsHeld;
            playerInventory.coinsHeld = 0;
        }

        if (coinsRequired <= 0)
        {
            Debug.Log("Game over! you won!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInventory = other.GetComponent<Inventory>();
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}