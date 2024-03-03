using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    public TextMeshProUGUI healthCounter;

    public GameObject playerStatus;

    private float currHealth;
    private float maxHealth;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        currHealth = playerStatus.GetComponent<PlayerStatusSystem>().currHealth;
        maxHealth = playerStatus.GetComponent<PlayerStatusSystem>().maxHealth;

        float fillValue = currHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currHealth + "/" + maxHealth;
    }
}
