using UnityEngine;

public class Altar : MonoBehaviour
{
    private Inventory playerInventory;

    private int coinsRequired = 1000;
    private int startingCoinsRequired;

    private bool inRange = false;

    private float maxY = 0.5f;
    private float minY = -0.5f;

    private float moveSpeed = 1f;

    [SerializeField] private GameObject hiddenDoor;
    [SerializeField] private GameObject singleCoin;
    [SerializeField] private GameObject multiCoin;
    [SerializeField] private GameObject coinStack;
    private void Start()
    {
        startingCoinsRequired = coinsRequired;
    }

    private void Update()
    {
        lowerAltar();
        depositCoins();
        ShowCoinPile();
        openDoor();
    }

    //checkt of de speler in bereik van het altaar is
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

    private void lowerAltar()
    {
        //veranderd de positie van het altaar gebaseerd op de hoeveelheid coins die gedeposit zijn
        float progress = 1f - (float)coinsRequired / startingCoinsRequired;

        float targetY = Mathf.Lerp(maxY, minY, progress);

        Vector3 pos = transform.position;
        pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);
        transform.position = pos;
    }

    private void depositCoins()
    {
        //Als de speler in bereik is en meer dan 50 coins heeft worden er 50 coins per keer gedeposit
        if (inRange && Input.GetKeyDown(KeyCode.E) && coinsRequired > 0 && playerInventory.coinsHeld > 50)
        {
            coinsRequired -= 50;
            playerInventory.coinsHeld -= 50;
        }

        //Als de speler in bereik is en minder dan 50 coins heeft worden alle resterende coins gedeposit
        else if (inRange && Input.GetKeyDown(KeyCode.E) && coinsRequired > 0)
        {
            coinsRequired -= playerInventory.coinsHeld;
            playerInventory.coinsHeld = 0;
        }
    }

    //Laat een stapel coins zien afhankelijk van hoeveel coins er gedeposit zijn
    private void ShowCoinPile()
    {
        if (coinsRequired < startingCoinsRequired / 100 * 15)
        {
            coinStack.SetActive(true);
        } else if (coinsRequired < startingCoinsRequired / 100 * 75)
        {
            multiCoin.SetActive(true);
        } else if (coinsRequired < startingCoinsRequired - 1)
        {
            singleCoin.SetActive(true);
        }
    }

    private void openDoor()
    {
        //als de vereiste munten is bereikt, beweeg de deur rustig omhoog
        if (coinsRequired <= 0)
        {
            Vector3 targetPosition = new Vector3(hiddenDoor.transform.position.x, 3.5f, hiddenDoor.transform.position.z);
            hiddenDoor.transform.position = Vector3.MoveTowards(hiddenDoor.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

    }
}