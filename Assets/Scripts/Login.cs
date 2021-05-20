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
    public string token;
}

public class Login : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Key;
    public GameObject KeyInput;
    public Toggle VR;
    public Text LoginError;
    public Text KeyError;

    void Start()
    {
        gameObject.SetActive(true);
        KeyInput.SetActive(false);
    }

    public void login(){

        string email = Email.text;
        string pass = Password.text;
        //API Call
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
            gameObject.SetActive(false);
            KeyInput.SetActive(true);
            Debug.Log("Received Token: " + res.token);
        }
        ////LoginError.text = "Invalid email or password";

        // if (email == "abc") // If user in database
        // {
        //     if (pass == "123") // If password is the user's password
        //     {
        //         gameObject.SetActive(false);
        //         KeyInput.SetActive(true);
        //     }
        //     else
        //         print("Wrong password");
        // }
        // else
        //     LoginError.text = "Invalid email or password";
    }

    public void StartExpt()
    {
        string key = Key.text;
        bool VRenable = VR.isOn;
        if (key == "simple-pendulum")
        {
            if (VRenable == false)
                SceneManager.LoadScene("Simple Pendulum");
            else
                SceneManager.LoadScene("Simple Pendulum VR");
        }
        else if (key == "hookes-law")
        {
            if (VRenable == false)
                SceneManager.LoadScene("Hookes Law");
            else
                SceneManager.LoadScene("Hookes Law VR");
        }
        else
            KeyError.text = "Invalid Key";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
