using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public GameObject Pendulum;
    public Text Mass;
    public Slider AdjMass;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int mass;
        double adj = AdjMass.value;
        Rigidbody Simple_Pendulum = Pendulum.GetComponent<Rigidbody>();
        if (adj<=0.2)
        mass = 50;
        else if (adj>0.2 && adj<=0.4)
        mass = 100;
        else if (adj>0.4 && adj<=0.6)
        mass = 150;
        else if (adj>0.6 && adj<=0.8)
        mass = 200;
        else
        mass = 250;
        Mass.text = "Mass = " + mass + "g";
        Simple_Pendulum.mass = mass;
    }
}
