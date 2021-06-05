using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddWeight : MonoBehaviour
{
    int mass;
    public Text Mass;
    public GameObject app;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = app.GetComponent<Rigidbody>();
        if (rb.mass%10==9)
        rb.mass=rb.mass+1;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            ChangeMass();
    }

    void ChangeMass()
    {
        Rigidbody rb = app.GetComponent<Rigidbody>();
        mass = (int) rb.mass;
        if (mass<250)
            mass+=50;
        rb.mass = mass;
        Mass.text = "Mass = " + mass + "g";
    }
}
