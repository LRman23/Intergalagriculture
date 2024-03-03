using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public static SelectionManager instance { get; set; }


    public bool onTarg;

    public GameObject selectedObject;

    public GameObject interactionInfo;
    TextMeshProUGUI interactionText;

    private void Start()
    {
        onTarg = false;
        interactionText = interactionInfo.GetComponent<TextMeshProUGUI>();
    }

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

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractableObject interact = selectionTransform.GetComponent<InteractableObject>();

            if (interact && interact.inRange)
            {
                onTarg = true;
                selectedObject = interact.gameObject;
                selectedObject = interact.gameObject;
                interactionText.text = interact.GetItemName();
                interactionInfo.SetActive(true);
            }
            else
            {
                onTarg = false;
                interactionInfo.SetActive(false);
            }

        }
        else
        {
            onTarg = false;
            interactionInfo.SetActive(false);
        }
    }
}
