﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changescenetoload : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 10)
        {
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
            Application.LoadLevel("ChoiceData");
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
        }
	}
}
