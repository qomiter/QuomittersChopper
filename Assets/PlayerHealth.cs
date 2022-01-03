using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float playerHealth = 50;
    public float maxPlayerHealth = 50;

    public GameObject healthBarUI;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        healthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();

        if (playerHealth < maxPlayerHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }

    }

    float CalculateHealth()
    {
        return playerHealth;
    }
}
