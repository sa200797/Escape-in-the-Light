﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    /*
    public int selectedWeapon = 0;


	// Use this for initialization
	void Start () {

        SelectWeapon();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {


            selectedWeapon++;

        }
    }*/

    public GameObject[] weapons;                // The array that holds all the weapons that the player has
    public int startingWeaponIndex = 0;         // The weapon index that the player will start with
    private int weaponIndex;                    // The current index of the active weapon


    




    // Use this for initialization
    void Start()
    {
        // Make sure the starting active weapon is the one selected by the user in startingWeaponIndex
        weaponIndex = startingWeaponIndex;
        SetActiveWeapon(weaponIndex);


      
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the user to instantly switch to any weapon
       /* if (Input.GetButtonDown("Weapon 1"))
            SetActiveWeapon(0);
        if (Input.GetButtonDown("Weapon 2"))
            SetActiveWeapon(1);
        if (Input.GetButtonDown("Weapon 3"))
            SetActiveWeapon(2);
        if (Input.GetButtonDown("Weapon 4"))
            SetActiveWeapon(3);
        if (Input.GetButtonDown("Weapon 5"))
            SetActiveWeapon(4);
        if (Input.GetButtonDown("Weapon 6"))
            SetActiveWeapon(5);
        if (Input.GetButtonDown("Weapon 7"))
            SetActiveWeapon(6);
        if (Input.GetButtonDown("Weapon 8"))
            SetActiveWeapon(7);
        if (Input.GetButtonDown("Weapon 9"))
            SetActiveWeapon(8);
            */
       
    }

   

    public void SetActiveWeapon(int index)
    {
        // Make sure this weapon exists before trying to switch to it
        if (index >= weapons.Length || index < 0)
        {
            Debug.LogWarning("Tried to switch to a weapon that does not exist.  Make sure you have all the correct weapons in your weapons array.");
            return;
        }

        // Send a messsage so that users can do other actions whenever this happens
        SendMessageUpwards("OnEasyWeaponsSwitch", SendMessageOptions.DontRequireReceiver);

        // Make sure the weaponIndex references the correct weapon
        weaponIndex = index;

        // Make sure beam game objects aren't left over after weapon switching
       // weapons[index].GetComponent<Weapon>().StopBeam();

        // Start be deactivating all weapons
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        // Activate the one weapon that we want
        weapons[index].SetActive(true);
    }

    
}




