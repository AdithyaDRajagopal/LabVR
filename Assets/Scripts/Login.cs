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
        if (key == "simple-pendulum")
            SceneManager.LoadScene("Simple Pendulum");
        else if (key == "hookes-law")
            SceneManager.LoadScene("Hookes Law");
        else
            print("Invlaid Key");
    }
}
