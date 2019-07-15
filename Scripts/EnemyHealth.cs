using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
public class EnemyHealth : MonoBehaviour {

    public GameObject healthGo;
    public Slider healthSlider;
    public  float health =100f ;
    public float currenthealth;
    public FirstPersonController player;
    public TextMeshProUGUI scoreUI;
    NewBehaviourScript NewBehaviour;
    int score;
    
   

    private Animator anim;

    // Use this for initialization
    
        public void Start()
    {
        //scoreUI = GameObject.Find("TextMeshPro Text").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        NewBehaviour = GetComponent<NewBehaviourScript>();
        currenthealth = health;
        
    }
    // Update is called once per frame
    void Update()
    {

       // healthGo.transform.LookAt(Camera.main.transform);
    }

    

    public void TakeDamage(float damage)
    {

         if (currenthealth <= 0)
         {

            //  Debug.Log("enemy destroy");

           
            NewBehaviour.Death();
            Destroy(gameObject,3f);
            
         
         /// scoreUI.text = ((int)player.score).ToString();
        }

        else 
        {
            currenthealth -= damage;
            
        }

        healthSlider.value = currenthealth;
    }
}

