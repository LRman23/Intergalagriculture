using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance { get; set; }

    public GameObject menuCanvas;

    public GameObject saveMenu;
    public GameObject settingsMenu;
    public GameObject menu;

    public bool isOpen;

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isOpen)
        {
            menuCanvas.SetActive(true);

            isOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            SelectionManager.instance.GetComponent<SelectionManager>().enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.M) && isOpen)
        {

            saveMenu.SetActive(false);
            settingsMenu.SetActive(false);
            menu.SetActive(true);

            menuCanvas.SetActive(false);
            isOpen = false;

            if(CraftingSystem.instance.isOpen == false && InventorySystem.Instance.isOpen == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            

            SelectionManager.instance.GetComponent<SelectionManager>().enabled = true;
        }
    }
}
