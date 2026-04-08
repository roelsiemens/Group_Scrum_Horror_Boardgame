using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class treasureChest : MonoBehaviour
{
    private MeshFilter meshFilter;
    public Mesh openedChestMesh;
    private Collider chestCollider;
    public GameObject coins;
    public TextMeshProUGUI chestText;

    private bool isPlayerInRange = false;
    private bool coinsInChest = false;
    private int randomNumber;
    private int goldCoinsFound;

    public int jumpscareChance = 10;
    public int itemChance = 10;
    public int emptyChance = 25;

    public int minGoldInChest = 250;
    public int maxGoldInChest = 500;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        chestCollider = GetComponent<Collider>();
        randomNumber = Random.Range(0, 101);
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            meshFilter.mesh = openedChestMesh;
            treasureReward();
            chestText.text = "Press 'Q' to pick up";
            if (!coinsInChest)
            {
                chestCollider.enabled = false;
                isPlayerInRange = false;
                chestText.text = "";
            }
        }
        if (isPlayerInRange && coinsInChest && Input.GetKeyDown(KeyCode.Q))
        {
            coinsInChest = false;
            coins.SetActive(false);
            chestCollider.enabled = false;
            isPlayerInRange = false;
            chestText.text = "";
            Debug.Log("You picked up " + goldCoinsFound + " gold coins!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the treasure chest area. Press 'E' to open it.");
            isPlayerInRange = true;
            if (!coinsInChest)
            {
                chestText.text = "Press 'E' to open";
            }
            else
            {
                chestText.text = "Press 'Q' to pick up";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player has left the treasure chest area.");
            isPlayerInRange = false;
            chestText.text = "";
        }
    }

    private void treasureReward()
    {
        if (randomNumber < jumpscareChance)
        {
            Debug.Log("jumpscare!");
        }
        else if (randomNumber >= jumpscareChance && randomNumber < jumpscareChance + itemChance)
        {
            Debug.Log("You found an item!");
        } 
        else if (randomNumber >= jumpscareChance + itemChance && randomNumber < jumpscareChance + itemChance + emptyChance)
        {
            Debug.Log("The chest is empty! Better luck next time!");
        }
        else
        {
            coinsInChest = true;
            coins.SetActive(true);
            goldAmountInChest();
            Debug.Log("You found gold coins!");
        }
    }

    private void goldAmountInChest()
    {
        goldCoinsFound = Random.Range(minGoldInChest, maxGoldInChest + 1);
    }
}
