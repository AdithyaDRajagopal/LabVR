using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text Status;
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
    }

    public void StopTimer()
    {
        print("STOP");
        running = false;
        Status.text = "RESET";
    }

    public void ResetTimer()
    {
        print("RESET");
        running = false;
        TimerText.text = "00:00:00";
        Status.text = "START";
    }
}