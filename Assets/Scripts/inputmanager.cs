using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputmanager : MonoBehaviour {
    private InputField inputField;
	// Use this for initialization
	void Start () {
        inputField = GetComponent<InputField>();
        InitInputField();
	}
    public void InputLogger()
    {

        string inputValue = inputField.text;

        Debug.Log(inputValue);
        SceneManager.LoadScene("manu2");

        InitInputField();
    }

    // Update is called once per frame
    void InitInputField () {
        inputField.text = "";
        inputField.ActivateInputField();
	}
}
