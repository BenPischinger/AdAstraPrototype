using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BenUITestHleathSystem : MonoBehaviour {

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }
    public float currentEnergy { get; set; }
    public float maxEnergy { get; set; }

    public Slider healthbar;
    public Slider energybar;

    private void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;

        maxEnergy = 100f;
        currentEnergy = maxEnergy;

        healthbar.value = CalculateHealth();
        energybar.value = CalculateEnergy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            DealDamage(10);

        if (Input.GetKeyDown(KeyCode.Alpha1))
            UseEnergy(10);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            UseEnergy(30);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            UseEnergy(50);

    }

    void DealDamage(float damageValue)
    {
        currentHealth -= damageValue;
        healthbar.value = CalculateHealth();

        if (currentHealth <= 0)
            Die();
    }

    void UseEnergy(float energyValue)
    {
        currentEnergy -= energyValue;
        energybar.value = CalculateEnergy();

        if (currentEnergy <= 0)
            Ooe();
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    float CalculateEnergy()
    {
        return currentEnergy/ maxEnergy;
    }

    void Die()
    {
        currentHealth = 0;
        Debug.Log("You Died");
    }

    void Ooe()
    {
        currentEnergy = 0;
        Debug.Log("Out of Energy");
    }

}
