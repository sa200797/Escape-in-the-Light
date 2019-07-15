using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShoot : MonoBehaviour {

   

    private Animator anim;

    public TextMeshProUGUI bulletLeftText;
    public TextMeshProUGUI bulletperMag;
    //public GameObject PannelMessage;

    private AudioSource _audioclip;
    public AudioClip shootsound;

    public int damagePerShot = 35;
    public int bulletsPerMag =  30;
    public int currentBullets = 30;
     

    public float fireRate = 0.1f;
    public float range = 250.0f;

    public float damage = 20.0f;


    public Transform shootPoint;
    public ParticleSystem muzzleFlash;



     public GameObject hitParticles;
     public GameObject bulletImpact;

    public static bool isfiring;

   

    float fireTimer;
    void Awake()
    {
        bulletperMag.text =  " "+"/" + ((int)bulletsPerMag).ToString();
        
        //  PannelMessage.SetActive(false);

    }

	// Use this for initialization
	void Start () {

        isfiring = false;

        bulletLeftText.text = ((int)currentBullets).ToString();

        currentBullets = bulletsPerMag;

        anim = GetComponent<Animator>();
        _audioclip = GetComponent<AudioSource>();
	}

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AK47")
        {
            currentBullets = 30;
            
            bulletLeftText.text = ((int)currentBullets).ToString();

            Debug.Log("Kuch nahi Ho raha!!");
        }

        if (other.gameObject.tag == "M4")
        {
            currentBullets = 60;

            bulletLeftText.text = ((int)currentBullets).ToString();

            Debug.Log("Kuch nahi Ho raha!!");
        }

        if (other.gameObject.tag == "ShotGun")
        {
            currentBullets = 07;

            bulletLeftText.text = ((int)currentBullets).ToString();

            Debug.Log("Kuch nahi Ho raha!!");
        }
    }

   


    /*
        
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "AK-47")
        {

            currentBullets = 30;

            bulletLeftText.text = ((int)currentBullets).ToString();

            Debug.Log("Kuch nahi Ho raha!!");

        }

    }*/



    // Update is called once per frame
    void Update () {
        if(Input.GetButton("Fire1"))
        {
            Fire();
        }
        else
        {
            NoHit();
        }
         
        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime;
	}

    
    private void Fire()
    {
        isfiring = true;

        if (fireTimer < fireRate || currentBullets <=0)

            return;
        

        RaycastHit hit;

        if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + "  found!!");

            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            hitParticleEffect.transform.SetParent(hit.transform);
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            bulletHole.transform.SetParent(hit.transform);

            Destroy(hitParticleEffect, 1f);
            Destroy(bulletHole, 1.5f);
            PlayerShootSound();

            if (hit.transform.GetComponent<ObjectHealth>())
            {
                hit.transform.GetComponent<ObjectHealth>().ApplyDamage(damage);

            }

            if(hit.transform.GetComponent<EnemyHealth>())
            {
               hit.transform.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }

        //GameObject hitParticleEffect = Instantiate(hitParticles[0], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

        /* if (GameObject.FindWithTag ("Wood"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[0], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            // GameObject bulletHole = Instantiate(bulletImpact[0], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Wood");
         }
         if (GameObject.FindWithTag("Metal"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[1], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
           //  GameObject bulletHole = Instantiate(bulletImpact[1], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Metal");
         }
         if (GameObject.FindWithTag ("Concerete"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[2], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
          //   GameObject bulletHole = Instantiate(bulletImpact[2], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Conc");
         }
         if (GameObject.FindWithTag ("Sand"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[3], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
           //  GameObject bulletHole = Instantiate(bulletImpact[3], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Sand");
         }
         if (GameObject.FindWithTag("Water"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[4], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
             //GameObject bulletHole = Instantiate(bulletImpact[4], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Water");
         }
         if (GameObject.FindWithTag("Dirt"))
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[5], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            // GameObject bulletHole = Instantiate(bulletImpact[5], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Dirt");
         }
         else
         {
             GameObject hitParticleEffect = Instantiate(hitParticles[6], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            // GameObject bulletHole = Instantiate(bulletImpact[6], hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
             Debug.Log("Default");
         }*/


        anim.SetBool("Fire", true);
        muzzleFlash.Play();
        bullets();
        fireTimer = 0.0f;


    }

   




    private void bullets()
    {
        if(isfiring == true)
        {
            currentBullets--;
            bulletLeftText.text = ((int)currentBullets).ToString();
        }

       
        
    }


    private void NoHit()
    {
        anim.SetBool("Fire", false);
    }

    private void PlayerShootSound()
    {
        _audioclip.clip = shootsound;
        _audioclip.Play();

            

    }
   
   
    
   
}
