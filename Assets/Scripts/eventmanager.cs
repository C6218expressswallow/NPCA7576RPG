﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventmanager : MonoBehaviour {
    public Text text;//ログのテキスト
    public Image image;//ログの背景
    public int flug = 0;//選択肢
    private bool whichflug = false;//選択ログを表示するかどうか
	void Start () {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
	}//ログを非表示
    private void Update()
    {
        if (whichflug)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

            }
        }
    }//選択ログの確認
    public void Log(string s)
    {
        text.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        text.text = s;
    }//ログを表示
    public int Which(string a="Yes",string b="No")
    {
        flug = 0;
        return flug;
    }//選択ログを開く
    public void Erase()
    {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        whichflug = false;
    }//ログを閉じる
}
