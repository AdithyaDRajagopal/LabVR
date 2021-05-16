using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Observations : MonoBehaviour
{
    private bool running;
    private float StartTime;
    private string Timefor10;
    private string TimePeriod;
    private int count;

    public GameObject Pendulum;
    public TMP_Text T10_1;
    public TMP_Text T10_2;
    public TMP_Text T10_3;
    public TMP_Text T10_4;
    public TMP_Text T10_5;
    public TMP_Text T1;
    public TMP_Text T2;
    public TMP_Text T3;
    public TMP_Text T4;
    public TMP_Text T5;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            float t = Time.time - StartTime;
            string seconds = (((int) (t/60))*60 + (int) t%60).ToString();
            string t1 = ((float) (((int) (t/60))*60 + (int) t%60)/10).ToString();
            string ms = (t%60 - ((int)t%60)).ToString("f2");
            Timefor10 = seconds+"."+ms[2]+ms[3];
            TimePeriod = t1+ms[2]+ms[3];
            if (seconds[seconds.Length-1] == '0')
            TimePeriod = t1+".0"+ms[2]+ms[3];
        }
    }

    public void PressBuzzer()
    {
        count = (count + 1) % 3;
        if (count == 0)
        Timefor10 = "-";
        else if (count == 1)
        {
            running = true;
            StartTime = Time.time;
        }
        else
        {
            running = false;
            RecordObs();
        }
    }

    void RecordObs()
    {
        Rigidbody Simple_Pendulum = Pendulum.GetComponent<Rigidbody>();
        int mass = (int) Simple_Pendulum.mass;
        if (mass == 50)
        {
            T10_1.text = Timefor10;
            T1.text = TimePeriod;
        }
        else if (mass == 100)
        {
            T10_2.text = Timefor10;
            T2.text = TimePeriod;
        }
        else if (mass == 150)
        {
            T10_3.text = Timefor10;
            T3.text = TimePeriod;
        }
        else if (mass == 200)
        {
            T10_4.text = Timefor10;
            T4.text = TimePeriod;
        }
        else
        {
            T10_5.text = Timefor10;
            T5.text = TimePeriod;
        }
    }

    public void Submit()
    {
        print("Observations Submitted...");
        SceneManager.LoadScene("Login");
    }
}