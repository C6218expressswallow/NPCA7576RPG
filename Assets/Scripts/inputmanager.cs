using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputmanager : MonoBehaviour
{
    private InputField inputField;
    //初期設定
    void Start()
    {
        inputField = GetComponent<InputField>();
        InitInputField();
    }
    //インプットフィールドから文字をもらう
    public void InputLogger()
    {

        string inputValue = inputField.text;

        Debug.Log(inputValue);
        SceneManager.LoadScene("manu2");

        InitInputField();
    }

    // インプットフィールド初期化
    void InitInputField()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }
}