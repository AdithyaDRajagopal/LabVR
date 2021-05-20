using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpringBehaviour : MonoBehaviour
{
    public Text Mass;
    public Slider AdjMass;
    Vector3 InitPos;
    Quaternion InitRot;
    Vector3 InitScale;
    public GameObject weights;

    public TMP_Text Reading1;
    public TMP_Text Reading2;
    public TMP_Text Reading3;
    public TMP_Text Reading4;
    public TMP_Text Reading5;
    public TMP_Text Ext1;
    public TMP_Text Ext2;
    public TMP_Text Ext3;
    public TMP_Text Ext4;
    public TMP_Text Ext5;

    void Start()
    {
        InitPos = transform.position;
        InitRot = transform.rotation;
        InitScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        int mass;
        double adj = AdjMass.value;
        if (adj<=0.1)
        mass = 0;
        else if (adj>0.1 && adj<=0.3)
        mass = 50;
        else if (adj>0.3 && adj<=0.5)
        mass = 100;
        else if (adj>0.5 && adj<=0.7)
        mass = 150;
        else if (adj>0.7 && adj<=0.9)
        mass = 200;
        else
        mass = 250;
        SpringAdjust(mass);
        AddWeights(mass);
        Mass.text = "Mass = " + mass + "g";
    }
    
    void SpringAdjust(int mass)
    {
        RecordObs(mass);
        if (mass == 0)
        {
            transform.position = InitPos;
            transform.localScale = InitScale;
        }
        else if (mass == 50)
        {
            transform.position = new Vector3(0.0f,14.0f,11.91f);
            transform.localScale = new Vector3(10.0f,11.0f,10.0f);
        }
        else if (mass == 100)
        {
            transform.position = new Vector3(0.0f,13.8f,11.91f);
            transform.localScale = new Vector3(10.0f,12.0f,10.0f);
        }
        else if (mass == 150)
        {
            transform.position = new Vector3(0.0f,13.6f,11.91f);
            transform.localScale = new Vector3(10.0f,13.0f,10.0f);
        }
        else if (mass == 200)
        {
            transform.position = new Vector3(0.0f,13.4f,11.91f);
            transform.localScale = new Vector3(10.0f,14.0f,10.0f);
        }
        else
        {
            transform.position = new Vector3(0.0f,13.2f,11.91f);
            transform.localScale = new Vector3(10.0f,15.0f,10.0f);
        }
        weights.transform.position = transform.position + new Vector3(0.0f,-0.2f,0.0f);
    }

    void RecordObs(int mass)
    {
        if (mass == 50)
        {
            Reading1.text = "17.6";
            Ext1.text = "1.6";
        }
        else if (mass == 100)
        {
            Reading2.text = "19.2";
            Ext2.text = "3.2";
        }
        else if (mass == 150)
        {
            Reading3.text = "20.8";
            Ext3.text = "4.8";
        }
        else if (mass == 200)
        {
            Reading4.text = "22.4";
            Ext4.text = "6.4";
        }
        else if (mass == 250)
        {
            Reading5.text = "24";
            Ext5.text = "8";
        }        
    }

    void AddWeights(int mass)
    {
        GameObject weight1 = weights.transform.GetChild (0).gameObject;
        GameObject weight2 = weights.transform.GetChild (1).gameObject;
        GameObject weight3 = weights.transform.GetChild (2).gameObject;
        GameObject weight4 = weights.transform.GetChild (3).gameObject;
        GameObject weight5 = weights.transform.GetChild (4).gameObject;
        if (mass == 0)
        {
            weight1.SetActive(false);
            weight2.SetActive(false);
            weight3.SetActive(false);
            weight4.SetActive(false);
            weight5.SetActive(false);
        }
        else if (mass == 50)
        {
            weight1.SetActive(true);
            weight2.SetActive(false);
            weight3.SetActive(false);
            weight4.SetActive(false);
            weight5.SetActive(false);
        }
        else if (mass == 100)
        {
            weight1.SetActive(true);
            weight2.SetActive(true);
            weight3.SetActive(false);
            weight4.SetActive(false);
            weight5.SetActive(false);
        }
        else if (mass == 150)
        {
            weight1.SetActive(true);
            weight2.SetActive(true);
            weight3.SetActive(true);
            weight4.SetActive(false);
            weight5.SetActive(false);
        }
        else if (mass == 200)
        {
            weight1.SetActive(true);
            weight2.SetActive(true);
            weight3.SetActive(true);
            weight4.SetActive(true);
            weight5.SetActive(false);
        }
        else
        {
            weight1.SetActive(true);
            weight2.SetActive(true);
            weight3.SetActive(true);
            weight4.SetActive(true);
            weight5.SetActive(true);
        }
    }

    public void Submit()
    {
        print("Observations Submitted...");
        SceneManager.LoadScene("Login");
    }
}
