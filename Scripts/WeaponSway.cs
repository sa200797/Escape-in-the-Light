﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour {

    public float amount;
    public float maxAmount;
    public float smoothAmout;

    private Vector3 initialPostion;
	// Use this for initialization
	void Start () {

        initialPostion = transform.localPosition;
        
	}
	
	// Update is called once per frame
	void Update () {

        float movementX = Input.GetAxis("Mouse X") * amount;
        float movementY = Input.GetAxis("Mouse Y") * amount;
        movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
        movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

        Vector3 finalPostion = new Vector3(movementX, movementY, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPostion + initialPostion, Time.deltaTime * smoothAmout);
	}
}
