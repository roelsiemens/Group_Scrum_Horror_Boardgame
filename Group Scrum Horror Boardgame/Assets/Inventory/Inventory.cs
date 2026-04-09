using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool leftHandEmpty = true;
    private bool rightHandEmpty = true;

    private GameObject leftHandItem;
    private GameObject rightHandItem;

    [SerializeField] private Camera playerCamera;
    [SerializeField] private float pickupRange = 3f;
    [SerializeField] private LayerMask pickupLayer;

    private float leftHoldTimer = 0f;
    private float rightHoldTimer = 0f;
    private float holdTimeToDrop = 1f;

    public TextMeshProUGUI coinText;
    public int coinsHeld;

    private void Update()
    {
        HandlePickup();
        HandleDrop();
        UpdateUI();
    }

    private void HandlePickup()
    {
        if (Input.GetMouseButtonDown(0) && leftHandEmpty)
        {
            TryPickupLeft();
        }

        if (Input.GetMouseButtonDown(1) && rightHandEmpty)
        {
            TryPickupRight();
        }
    }

    private GameObject GetItemInSight()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
        {
            if (hit.collider.CompareTag("pickUp"))
            {
                return hit.collider.gameObject;
            }
        }

        return null;
    }

    private void TryPickupLeft()
    {
        GameObject hitItem = GetItemInSight();

        if (hitItem == null) return;

        leftHandItem = hitItem;

        PrepareItemForPickup(leftHandItem);
        AttachToHand(leftHandItem, new Vector3(-0.6f, 0, 0.75f));

        leftHandEmpty = false;
    }

    private void TryPickupRight()
    {
        GameObject hitItem = GetItemInSight();

        if (hitItem == null) return;

        rightHandItem = hitItem;

        PrepareItemForPickup(rightHandItem);
        AttachToHand(rightHandItem, new Vector3(0.6f, 0, 0.75f));

        rightHandEmpty = false;
    }

    private void PrepareItemForPickup(GameObject item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        Collider col = item.GetComponent<Collider>();

        if (rb != null) rb.isKinematic = true;
        if (col != null) col.enabled = false;
    }

    private void AttachToHand(GameObject item, Vector3 localPos)
    {
        item.transform.SetParent(transform);
        item.transform.SetLocalPositionAndRotation(localPos, Quaternion.Euler(15, 0, 0));
    }

    private void HandleDrop()
    {
        if (Input.GetMouseButton(0) && !leftHandEmpty)
        {
            leftHoldTimer += Time.deltaTime;

            if (leftHoldTimer >= holdTimeToDrop)
            {
                DropLeftHand();
                leftHoldTimer = 0f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            leftHoldTimer = 0f;
        }

        if (Input.GetMouseButton(1) && !rightHandEmpty)
        {
            rightHoldTimer += Time.deltaTime;

            if (rightHoldTimer >= holdTimeToDrop)
            {
                DropRightHand();
                rightHoldTimer = 0f;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            rightHoldTimer = 0f;
        }
    }

    private void DropLeftHand()
    {
        if (leftHandEmpty) return;

        ReleaseItem(leftHandItem);
        leftHandItem = null;
        leftHandEmpty = true;
    }

    private void DropRightHand()
    {
        if (rightHandEmpty) return;

        ReleaseItem(rightHandItem);
        rightHandItem = null;
        rightHandEmpty = true;
    }

    private void ReleaseItem(GameObject item)
    {
        item.transform.SetParent(null);

        Rigidbody rb = item.GetComponent<Rigidbody>();
        Collider col = item.GetComponent<Collider>();

        if (rb != null) rb.isKinematic = false;
        if (col != null) col.enabled = true;
    }

    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsHeld;
        }
    }
}