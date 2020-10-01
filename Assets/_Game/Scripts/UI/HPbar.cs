using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    public Slider Healthbar;
    public Text Healthtext;
    public PlayerStats m_PlayerHandler;


    public float MaxHealth { get; set; }




    // Use this for initialization
    void Start()
    {

        //Initalisierung der HP werte 

        MaxHealth = m_PlayerHandler.GetValue(m_PlayerHandler, "Health");

        Healthbar.value = CalculateHealth();

		Healthtext.text = m_PlayerHandler.GetValue(m_PlayerHandler, 0) + "/" + MaxHealth; //oder ... GetValue(m_PlayerHandler, "Health")



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage();
        }

        Healthbar.value = CalculateHealth();
        Healthtext.text = m_PlayerHandler.GetValue(m_PlayerHandler, "Health") + "/" + MaxHealth;

    }
    void DealDamage()
    {
        m_PlayerHandler.SetValue(m_PlayerHandler, "Health", -10);

        if (m_PlayerHandler.GetValue(m_PlayerHandler, "Health") <= 0)
            Die();
    }

    float CalculateHealth()
    {
        return m_PlayerHandler.GetValue(m_PlayerHandler, "Health") / MaxHealth;
    }


    void Die()
    {
        if (m_PlayerHandler.GetValue(m_PlayerHandler, "Health") <= 0)
            Debug.Log("Your are Dead!");
    }



}
