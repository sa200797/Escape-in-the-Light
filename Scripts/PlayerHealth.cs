﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
   // public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 3f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


    Animator anim;                                              // Reference to the Animator component.
    AudioSource playerAudio;                                    // Reference to the AudioSource component.
    FirstPersonController playerMovement;                              // Reference to the player's movement.
    WeaponShoot playerShooting;                              // Reference to the PlayerShooting script.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.

    //public GameOver gameover;

    public GameObject player;
    public GameObject GameOver_Pannel;
    GameObject[] Enemy;
  //  public Canvas gameoverCanvas;

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<FirstPersonController>();
        playerShooting = GetComponentInChildren<WeaponShoot>();

        // Set the initial health of the player.
        currentHealth = startingHealth;

        Enemy = GameObject.FindGameObjectsWithTag("Enemy");



        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

        if(isDead)
        {
            foreach (GameObject i in Enemy)
            {
                i.SetActive(false);
                Debug.Log("Done");
            }
        }
    }


    public void TakeDamage(int Damage)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= Damage;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;
        GameOver_Pannel.SetActive(true);
        player.SetActive(false);
        playerAudio.Stop();

        /*foreach (GameObject i in Enemy)
        {
            i.SetActive(false);
        }*/


        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;




        // gameoverCanvas.enabled = true;
        // gameover.Playerover();
        //player.SetActive(false);
        // Turn off any remaining shooting effects.
        // playerShooting.DisableEffects();

        // Tell the animator that the player is dead.


        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        // playerAudio.clip = deathClip;
        // playerAudio.Play();

        // Turn off the movement and shooting scripts.
        // playerMovement.enabled = false;
        // playerShooting.enabled = false;


    }

    /*
        public void RestartLevel()
        {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene(0);
        }

    */
}

