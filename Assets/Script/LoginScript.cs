using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class LoginScript : MonoBehaviour {

    public GameObject username;
    public GameObject password;
    public GameObject login;

    public Button btnLogin;

    private string Username;
    private string Password;

    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
	}
	
	// Update is called once per frame
	void Update () {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;

        btnLogin = login.GetComponent<Button>();
        btnLogin.onClick.AddListener(validateLogin);

    }

    private void validateLogin()
    {
        if(Username != "" && Password != "")
        {
            print("Login successful");
            EnableVR();
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }

    void EnableVR()
    {
        StartCoroutine(LoadDevice("daydream", true));
    }

}
