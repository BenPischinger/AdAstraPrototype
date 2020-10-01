using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEnergyBarUi : MonoBehaviour {
    public Slider HealthBar;

    public Slider EnergyBar;

    private HealthSystem playerHealth;
    private EnergyComponent playerEnergy;

    // Use this for initialization
    void Start() {
        playerHealth = GameManager.Instance.Player.GetComponent<HealthSystem>();
        playerEnergy = GameManager.Instance.Player.GetComponent<EnergyComponent>();
    }

    // Update is called once per frame
    void Update() {
        HealthBar.normalizedValue = playerHealth.Health/(float)playerHealth.MaxHealth;
        EnergyBar.normalizedValue = playerEnergy.Energy/(float)playerEnergy.MaxEnergy;
    }
}