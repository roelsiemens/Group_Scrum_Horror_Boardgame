using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool leftHandEmpty = true;
    private bool rightHandEmpty = true;
    private bool itemInRange = false;

    private GameObject item;
    private GameObject leftHandItem;
    private GameObject rightHandItem;

    private float leftHoldTimer = 0f;
    private float rightHoldTimer = 0f;
    private float holdTimeToDrop = 1f;

    private void Update()
    {
        if (leftHandEmpty && Input.GetMouseButtonDown(0))
        {
            LeftHandPickup();
        }
        if (rightHandEmpty && Input.GetMouseButtonDown(1))
        {
            RightHandPickup();
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            itemInRange = true;
            item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp"))
        {
            itemInRange = false;
        }
    }

    private void RightHandPickup()
    {
        if (itemInRange && rightHandEmpty)
        {
            rightHandItem = item;
            rightHandItem.GetComponent<Rigidbody>().isKinematic = true;
            rightHandItem.GetComponent<Collider>().enabled = false;
            item = null;
            itemInRange = false;
            rightHandItem.transform.SetParent(transform);
            rightHandItem.transform.SetLocalPositionAndRotation(new Vector3(0.6f, 0, 0.75f), Quaternion.Euler(15, 0, 0));
            rightHandEmpty = false;
        }
    }

    private void LeftHandPickup()
    {
        if (itemInRange && leftHandEmpty)
        {
            leftHandItem = item;
            leftHandItem.GetComponent<Rigidbody>().isKinematic = true;
            leftHandItem.GetComponent<Collider>().enabled = false;
            item = null;
            itemInRange = false;
            leftHandItem.transform.SetParent(transform);
            leftHandItem.transform.SetLocalPositionAndRotation(new Vector3(-0.6f, 0, 0.75f), Quaternion.Euler(15, 0, 0));
            leftHandEmpty = false;
        }
    }

    private void DropLeftHand()
    {
        if (!leftHandEmpty)
        {
            leftHandItem.transform.SetParent(null);
            leftHandItem.GetComponent<Rigidbody>().isKinematic = false;
            leftHandItem.GetComponent<Collider>().enabled = true;
            leftHandItem = null;
            leftHandEmpty = true;
        }
    }

    private void DropRightHand()
    {
        if (!rightHandEmpty)
        {
            rightHandItem.transform.SetParent(null);
            rightHandItem.GetComponent<Rigidbody>().isKinematic = false;
            rightHandItem.GetComponent<Collider>().enabled = true;
            rightHandItem = null;
            rightHandEmpty = true;
        }
    }
}
