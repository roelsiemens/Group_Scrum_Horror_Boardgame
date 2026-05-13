using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class treasureChest : MonoBehaviour
{
    private MeshFilter meshFilter;
    [SerializeField] private Mesh openedChestMesh;
    private Collider chestCollider;
    [SerializeField] private GameObject coins;
    [SerializeField] private GameObject spell;

    private bool isPlayerInRange = false;
    private bool coinsInChest = false;
    private int randomNumber;
    private int goldCoinsFound;

    [SerializeField] private int jumpscareChance = 10;
    [SerializeField] private int itemChance = 10;
    [SerializeField] private int emptyChance = 25;

    [SerializeField] private int minGoldInChest = 250;
    [SerializeField] private int maxGoldInChest = 500;

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
        openChest();
        pickupCoins();
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

    private void openChest()
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
    }

    private void pickupCoins()
    {
        if (isPlayerInRange && coinsInChest && Input.GetKeyDown(KeyCode.E))
        {
            coinsInChest = false;
            coins.SetActive(false);
            chestCollider.enabled = false;
            isPlayerInRange = false;
            playerInventory.coinsHeld += goldCoinsFound;
        }
    }

    //Bepaald de inhoud van de chest op basis van een willekeurig getal en de ingestelde kansen voor een jumpscare, item, lege chest of geld.
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

    //bepaald de hoeveelheid coins die in de kist zitten op basis van de minimum en maximum hoeveelheid die ingesteld is
    private void goldAmountInChest()
    {
        goldCoinsFound = Random.Range(minGoldInChest, maxGoldInChest + 1);
    }
}
