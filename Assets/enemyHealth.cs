using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float health = 25;
    public float maxHealth = 25;

    public GameObject healthBarUI;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = CalculateHealth();

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

    float CalculateHealth()
    {
        return health;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        health = health - 1f;
    }
}
