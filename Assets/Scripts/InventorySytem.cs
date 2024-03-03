using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreen;

    public List<GameObject> slotList = new List<GameObject>();

    public List<string> itemList = new List<string>();

    private GameObject itemAdd;
    private GameObject openSlot;


    public bool isOpen;

    //Pickup Popup Box
    public GameObject pickupAlert;
    public TextMeshProUGUI itemPickupName;
    public Image itemPickupImage;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Start()
    {
        isOpen = false;

        PopulateSlotList();
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreen.transform)
        {
            if (child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen && !CraftingSystem.instance.isOpen)
        {

            Debug.Log("Tab is pressed");
            Cursor.lockState = CursorLockMode.None;
            inventoryScreen.SetActive(true);
            isOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            inventoryScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false;
        }
    }

    public void AddToInventory(string itemName)
    {
        openSlot = FindNextEmptySlot();
        itemAdd = Instantiate(Resources.Load<GameObject>(itemName), openSlot.transform.position, openSlot.transform.rotation);
        itemAdd.transform.SetParent(openSlot.transform);
        itemList.Add(itemName);

        TriggerPickupPopup(itemName, itemAdd.GetComponent<Image>().sprite);

    }

    void TriggerPickupPopup(string itemName, Sprite itemSprite)
    {
        pickupAlert.SetActive(true);

        itemPickupName.text = itemName;
        itemPickupImage.sprite = itemSprite;
    }

    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }

        return new GameObject();
    }

    public bool CheckIfFull()
    {
        int counter = 0;

        foreach (GameObject slot in slotList)
        {
            if (slot.transform.childCount > 0)
            {
                counter += 1;
            }
        }

        if (counter == 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
