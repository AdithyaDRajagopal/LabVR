using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWeight : MonoBehaviour
{
    int mass;
    public GameObject spring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            ChangeMass();
    }

    void ChangeMass()
    {
        Rigidbody Spring = spring.GetComponent<Rigidbody>();
        mass = (int) Spring.mass;
        if (mass>1)
            mass-=50;
        Spring.mass = mass;
    }
}
