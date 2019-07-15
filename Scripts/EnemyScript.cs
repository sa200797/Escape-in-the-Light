using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {

    NavMeshAgent nav;
    public GameObject player;

    private Animator anim;

    // Use this for initialization
    void Start () {

       
        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        nav.SetDestination(player.transform.position);
       
	}
}
