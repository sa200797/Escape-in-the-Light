using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;


    bool isDead;


    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amount, Vector3 hitpoint)
    {
        if (isDead)
            return;


        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;
        gameObject.SetActive(false);
    }


}


