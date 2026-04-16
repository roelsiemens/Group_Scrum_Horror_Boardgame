using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class treasureChest : MonoBehaviour
{
    private MeshFilter meshFilter;
    public Mesh openedChestMesh;
    private Collider chestCollider;
    public GameObject coins;
    public GameObject spell;

    private bool isPlayerInRange = false;
    private bool coinsInChest = false;
    private int randomNumber;
    private int goldCoinsFound;

    public int jumpscareChance = 10;
    public int itemChance = 10;
    public int emptyChance = 25;

    public int minGoldInChest = 250;
    public int maxGoldInChest = 500;

    private Inventory playerInventory;
    private JumpScareManager jumpScareManager;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        chestCollider = GetComponent<Collider>();
        jumpScareManager = GetComponent<JumpScareManager>();
        randomNumber = Random.Range(0, 101);
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyUp(KeyCode.E))
        {
            meshFilter.mesh = openedChestMesh;
            treasureReward();
            if (!coinsInChest)
            {
                chestCollider.enabled = false;
                isPlayerInRange = false;
            }
        }
        if (isPlayerInRange && coinsInChest && Input.GetKeyDown(KeyCode.E))
        {
            coinsInChest = false;
            coins.SetActive(false);
            chestCollider.enabled = false;
            isPlayerInRange = false;
            playerInventory.coinsHeld += goldCoinsFound;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInventory = other.GetComponent<Inventory>();
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }

    private void treasureReward()
    {
        if (randomNumber < jumpscareChance)
        {
            jumpScareManager.GetJumpScared(5);
        }
        else if (randomNumber >= jumpscareChance && randomNumber < jumpscareChance + itemChance)
        {
            spell.SetActive(true);
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
        }
    }

    private void goldAmountInChest()
    {
        goldCoinsFound = Random.Range(minGoldInChest, maxGoldInChest + 1);
    }
}
