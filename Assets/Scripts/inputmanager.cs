using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inputmanager : MonoBehaviour
{
    public GameObject obj;
    private InputField inputField;
    private static string inputValue;
    public keepdata keeper;
    //初期設定
    void Start()
    {
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
        if (Application.loadedLevelName == "manu")
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
        {
            inputField = obj.GetComponent<InputField>();
            InitInputField();
        }
    }
    //インプットフィールドから文字をもらう
    public void InputLogger()
    {
        if (inputValue == null)
        {
            inputValue = inputField.text;
            Debug.Log(inputValue);
            keeper.datasname = inputValue;
            InitInputField();
        }
    }

    // インプットフィールド初期化
    void InitInputField()
    {
        inputField.text = "";
        inputField.ActivateInputField();
    }
    public string Getname()
    {
        return inputValue;
    }

    public void LoadScene()
    {

        SceneManager.LoadScene("manu2");
        Debug.Log(inputValue);
    }
}