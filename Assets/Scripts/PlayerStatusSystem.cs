using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusSystem : MonoBehaviour
{

    public static PlayerStatusSystem instance { get; set; }
    public GameObject playerBody;

    // Player Health //
    public float currHealth;
    public float maxHealth;

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
        currHealth = maxHealth;
    }


    void Update()
    {
        
    }
}
