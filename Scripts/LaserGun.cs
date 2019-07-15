using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour {

    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    float timer;

    LineRenderer gunLine;
    float effectDisplayTimer = 0.2f;

    bool isShooting = false;

    Camera fpsCamera;

    public Transform gunEnd;

    void Awake()
    {
        gunLine = gunEnd.GetComponent<LineRenderer>();
        fpsCamera = GetComponent<Camera>();
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (isShooting == true && timer >= timeBetweenBullets)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets && timer >= timeBetweenBullets)
        {
            DisableEffects();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        
        }
        else
        {
            isShooting = false;

        }
    }
    public void DisableEffects()
    {
        gunLine.enabled = false;

    }

    void Shoot()
    {
        gunLine = gunEnd.GetComponent<LineRenderer>();
        timer = 0f;

        gunLine.enabled = true;

        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;

        gunLine.SetPosition(0, gunEnd.position);
        gunLine.SetPosition(1, gunEnd.position + (fpsCamera.transform.forward * range));

    }

}
