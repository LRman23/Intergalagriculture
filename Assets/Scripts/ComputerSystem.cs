using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{

    public GameObject computerScreen;
    public GameObject robotScreen;
    public GameObject robotUpgradeScreen;
    public GameObject baseBuildingScreen;

    public List<string> inventoryItems = new List<string>();

    //Category Buttons
    Button robotButton;
    Button robotUpgButton;
    Button baseBuildingButton;

    //Robot Buttons

    //Robot Upgrade Buttons

    //Base Building Buttons


    //Requirement Text
    

    public bool isOpen;

    //All Blueprints


    public static CraftingSystem instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }



    void Start()
    {
        isOpen = false;

        robotButton = computerScreen.transform.Find("RobotButton").GetComponent<Button>();
        robotButton.onClick.AddListener(delegate { openRobotCategory(); });

        robotUpgButton = computerScreen.transform.Find("RobotUpgradeButton").GetComponent<Button>();
        robotUpgButton.onClick.AddListener(delegate { openRobotUpgradeCategory(); });

        baseBuildingButton = computerScreen.transform.Find("BaseBuildingButton").GetComponent<Button>();
        baseBuildingButton.onClick.AddListener(delegate { openBaseBuildingCategory(); });
    }

    private void openBaseBuildingCategory()
    {
        computerScreen.SetActive(false);
        baseBuildingScreen.SetActive(true);
    }

    private void openRobotUpgradeCategory()
    {
        computerScreen.SetActive(false);
        robotUpgradeScreen.SetActive(true);
    }

    private void openRobotCategory()
    {
        computerScreen.SetActive(false);
        robotScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !isOpen && !InventorySystem.Instance.isOpen)
        {
            Debug.Log("c is pressed");
            computerScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isOpen)
        {
            computerScreen.SetActive(false);
            robotScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            isOpen = false;
        }
    }
}