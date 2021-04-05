using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    //public TextMeshProUGUI Status;
    private float StartTime;
    private bool running;
    private int count = 0;

    void Start()
    {
        ResetTimer();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText = GetComponent<TextMeshProUGUI>();
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
        }
    }

    public void StartTimer()
    {
        //Status = GetComponent<TextMeshProUGUI>();
        count = (count + 1)%3;
        if (count == 1)
        {
            print ("START");
            running = true;
            StartTime = Time.time;
            //Status.text = "STOP";
        }
        else if (count == 2)
        StopTimer();
        else
        ResetTimer();
    }

    public void StopTimer()
    {
        //Status = GetComponent<TextMeshProUGUI>();
        print("STOP");
        running = false;
        //Status.text = "RESET";
    }

    public void ResetTimer()
    {
        TimerText = GetComponent<TextMeshProUGUI>();
        //Status = GetComponent<TextMeshProUGUI>();
        print("RESET");
        running = false;
        TimerText.text = "00:00:00";
    }
}
