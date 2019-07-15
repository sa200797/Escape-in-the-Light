using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch3 : MonoBehaviour {

	public WeaponManager weaponManager;

    
    public GameObject Ak_47UI;
    public GameObject M4_WeaponUI;
    public GameObject ShotGunUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            weaponManager.SetActiveWeapon(3);
            


            Ak_47UI.SetActive(false);
            M4_WeaponUI.SetActive(false);
            ShotGunUI.SetActive(true);

        }

    }
}

