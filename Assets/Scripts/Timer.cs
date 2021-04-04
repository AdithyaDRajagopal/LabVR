using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float StartTime;
   
    void Start()
    {
        StartTime = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        TimerText = GetComponent<TextMeshProUGUI>();
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
        //TimerText.SetText(minutes + ":" + seconds);
        TimerText.text = minutes+":"+seconds+":"+ms[2]+ms[3];
    }
}
