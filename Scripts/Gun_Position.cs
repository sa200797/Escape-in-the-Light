using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Position : MonoBehaviour
{
    [SerializeField] Transform hand;

    // Start is called before the first frame update
    void Awake()
    {
        transform.SetParent(hand);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
