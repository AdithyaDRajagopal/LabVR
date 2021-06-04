using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class UserData 
{
    public string user="student";
    public string password;
    public string email;
}

public class Response{
    public string message;
    public string type;
    public string token;
}

public class Login : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Key;
    public GameObject Inputs;
    public GameObject KeyInput;
    public Toggle VR;
    public Text LoginError;
    public Text KeyError;

    void Start()
    {
    Inputs.SetActive(true);
        KeyInput.SetActive(false);
    }

    public void login(){

        print("hi");

        string email = Email.text;
        string pass = Password.text;
        //API Call
        print(email);
        StartCoroutine(loginAuth(email, pass));
    }

    public  IEnumerator loginAuth(string email, string pass)
    {
        var user = new UserData();
        user.email = email;
        user.password = pass;
        string json = JsonUtility.ToJson(user);

        var req = new UnityWebRequest("https://vrlabserver.herokuapp.com/api/login", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();

        if (req.isNetworkError){
            Debug.Log("Error While Sending: " + req.error);
            LoginError.text = "Network issues";
        }
        else if(req.isHttpError){
            Debug.Log("Error While Sending: " + req.error);
            var res=new Response();
            JsonUtility.FromJsonOverwrite(req.downloadHandler.text, res);
            Debug.Log("Error: " + res.message);
            LoginError.text = res.message;
        }
        else{
            var res=new Response();
            JsonUtility.FromJsonOverwrite(req.downloadHandler.text, res);
        Inputs.SetActive(false);
            KeyInput.SetActive(true);
            Debug.Log("Received Token: " + res.token);
            PlayerPrefs.SetString("token",res.token);
            PlayerPrefs.Save();
            var token=PlayerPrefs.GetString("token");
            print(token);
        }

       
    }

    public void StartExpt()
    {
        string key = Key.text;

//Inputs.SetActive(true);

// Debug.Log(key);


        StartCoroutine(expStart(key));

       

        


        
       
    }

    public IEnumerator expStart(string key){

 bool VRenable = VR.isOn;

        // string json = JsonUtility.ToJson(user);

// Debug.Log("hjfbsf");
var token=PlayerPrefs.GetString("token");
var url="https://vrlabserver.herokuapp.com/api/result/start/"+token;
Debug.Log(url);
           
        // var req = new UnityWebRequest(url, "POST");
        // byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(key);
        // req.uploadHandler = (UploadHandler)new UploadHandlerRaw(key);
        // req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        // req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns

        WWWForm form=new WWWForm();
        form.AddField("key",key);

        
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                
            }
            else
            {
                // Debug.Log("Form upload complete!");
                PlayerPrefs.SetString("key",key);
                Debug.Log(www.downloadHandler.text);
                

                 var res=new Response();
            JsonUtility.FromJsonOverwrite(www.downloadHandler.text, res);
                Debug.Log(res.type);

                if (res.type == "simple-pendulum")
        {
            if (VRenable == false)
                SceneManager.LoadScene("Simple Pendulum");
            else
                SceneManager.LoadScene("Simple Pendulum VR");
        }
        else if (res.type == "hookes-law")
        {
            if (VRenable == false)
                SceneManager.LoadScene("Hookes Law");
            else
                SceneManager.LoadScene("Hookes Law VR");
        }
        else
            KeyError.text = "Invalid Key";

            }
        }
       



        // yield return req.SendWebRequest();

        // if (req.isNetworkError){
        //     Debug.Log("Error While Sending: " + req.error);
        //     LoginError.text = "Network issues";
        // }
        // else if(req.isHttpError){
        //     Debug.Log("Error While Sending: " + req.error);
        //     var res=new Response();
        //     JsonUtility.FromJsonOverwrite(req.downloadHandler.text, res);
        //     Debug.Log("Error: " + res.message);
        //     LoginError.text = res.message;
        // }
        // else{
        //     var res=new Response();

        //     Debug.Log(res);

           

        // if (res.type == "simple-pendulum")
        // {
        //     if (VRenable == false)
        //         SceneManager.LoadScene("Simple Pendulum");
        //     else
        //         SceneManager.LoadScene("Simple Pendulum VR");
        // }
        // else if (res.type == "hookes-law")
        // {
        //     if (VRenable == false)
        //         SceneManager.LoadScene("Hookes Law");
        //     else
        //         SceneManager.LoadScene("Hookes Law VR");
        // }
        // else
        //     KeyError.text = "Invalid Key";



        //     JsonUtility.FromJsonOverwrite(req.downloadHandler.text, res);
        //    Inputs.SetActive(false);
        //     KeyInput.SetActive(true);
           
        


    }

    public void ExitGame()
    {
        //  PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
