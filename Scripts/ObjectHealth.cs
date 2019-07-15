using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    //public GameObject rockhit;

    public GameObject rockHit;

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if(health <= 0f )
        {
            health = 0.0f;
            Debug.Log("Objected Destoryed");
        
            if(gameObject.tag == "Rock")
            {
                Instantiate(rockHit, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }

        }
    }
}
    
    /*

    public int startingHealth = 100;
    public int currentHealth;


    bool isDead;

    BoxCollider boxcollider;


    // Use this for initialization
    void Start()
    {
        currentHealth = startingHealth;
        boxcollider = GetComponent<BoxCollider>();
        
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
        Debug.Log("Death");
    }

    */
