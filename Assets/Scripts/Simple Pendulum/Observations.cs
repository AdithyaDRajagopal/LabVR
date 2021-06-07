using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;



public class Data{
    public string[] result;
    public string choice;
}



public class Result{
    public string time;
    public int weight;

    public Result(string t,int w){
        time=t;
        weight=w;
    }

    
}

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

    public GameObject MCQ;
    public GameObject Other;

    void Start()
    {
        count = 0;
        MCQ.SetActive(false);
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
        MCQ.SetActive(true);
        Other.SetActive(false);
    }

    public void SubmitA()
    {
        SubmitObs("T=2π √(ml/g)");
        print("T=2π √(ml/g)");
    }

    public void SubmitB()
    {
        SubmitObs("T=2π √(l/g)");
        print("T=2π √(l/g)");
    }

    public void SubmitC()
    {
        SubmitObs("T=2π √(g/l)");
        print("T=2π √(g/l)");
    }

    public void SubmitD()
    {
        SubmitObs("T=2πm √(l/g)");
        print("T=2πm √(l/g)");
    }

    void SubmitObs(string option)
    {
        var token=PlayerPrefs.GetString("token");
        var key=PlayerPrefs.GetString("key");
        print("Trying to Submit Observations...");
        StartCoroutine(expSubmit(token, key, option));
    }

    public IEnumerator expSubmit(string token,string key, string option){

        var url="https://vrlabserver.herokuapp.com/api/result/submit/"+token;
        WWWForm form=new WWWForm();
        form.AddField("key",key);
        
        string[] r=new string[5];
        r[0]=JsonUtility.ToJson( new Result(T1.text,50));
        r[1]= JsonUtility.ToJson(new Result(T2.text,100));
        r[2]=JsonUtility.ToJson( new Result(T3.text,150));
        r[3]= JsonUtility.ToJson(new Result(T4.text,200));
        r[4]= JsonUtility.ToJson(new Result(T5.text,250));

        Data d=new Data();
        d.result=r;
        d.choice=option;
        string json = JsonUtility.ToJson(d);
        form.AddField("result",json);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
        
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                
            }
            else
            {
                Debug.Log("Observation Submitted....");
                SceneManager.LoadScene("Login");
            }

    }
    }
}