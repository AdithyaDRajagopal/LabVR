using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerRecord : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text Status;
    private float StartTime;
    private bool running;
    private int count = 0;
    private string Timefor10;
    private string TimePeriod;

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
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            float t = Time.time - StartTime;
            string minutes = ((int) t/60).ToString();
            if(((int) t/60) < 10)
            {
                minutes = "0" + minutes;
            }
            string seconds = ((int) t%60).ToString();
            if(((int) t%60) < 10)
            {
                seconds = "0" + seconds;
            }
            string ms = (t%60 - ((int)t%60)).ToString("f2");
            TimerText.text = minutes+":"+seconds+":"+ms[2]+ms[3];

            string s = (((int) (t/60))*60 + (int) t%60).ToString();
            string t1 = ((float) (((int) (t/60))*60 + (int) t%60)/10).ToString();
            string m = (t%60 - ((int)t%60)).ToString("f2");
            Timefor10 = s+"."+m[2]+m[3];
            TimePeriod = t1+m[2]+m[3];
            if (s[s.Length-1] == '0')
            TimePeriod = t1+".0"+m[2]+m[3];
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            PressBuzzer();
    }

    public void PressBuzzer()
    {
        count = (count + 1) % 3;
        if (count == 0)
        ResetTimer();
        else if (count == 1)
        StartTimer();
        else
        StopTimer();
    }

    public void StartTimer()
    {
        print ("START");
        running = true;
        StartTime = Time.time;
        Status.text = "STOP";
        Oscillate();
    }

    public void StopTimer()
    {
        print("STOP");
        running = false;
        Status.text = "RESET";
        RecordObs();
    }

    public void ResetTimer()
    {
        print("RESET");
        running = false;
        TimerText.text = "00:00:00";
        Status.text = "START";
        Timefor10 = "-";
        ResetPendulumPosition();
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

    void Oscillate()
    {
        Rigidbody rb = Pendulum.GetComponent<Rigidbody>();
        Pendulum.transform.position = new Vector3(4.1f, 13.6f, 11.8f);
        Pendulum.transform.rotation = new Quaternion(0.0f, 0.0f, 0.6f, 0.8f);
    }

    void ResetPendulumPosition()
    {
        Rigidbody rb = Pendulum.GetComponent<Rigidbody>();
        Pendulum.transform.position = new Vector3(0.5f, 13.9f, 11.8f);
        Pendulum.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
