using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Key;
    public GameObject KeyInput;
    public Toggle VR;

    void Start()
    {
        gameObject.SetActive(true);
        KeyInput.SetActive(false);
    }

    public void login()
    {
        string email = Email.text;
        string pass = Password.text;
        if (email == "abc") // If user in database
        {
            if (pass == "123") // If password is the user's password
            {
                gameObject.SetActive(false);
                KeyInput.SetActive(true);
            }
            else
                print("Wrong password");
        }
        else
            print("User Invalid");
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
            print("Invlaid Key");
    }
}
