using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventmanager : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        text.gameObject.SetActive(false);
	}
    public void Log(string s)
    {
        text.gameObject.SetActive(true);
        text.text = s;
    }
    public int Which(string a="Yes",string b="No")
    {
        int c;
        c = 0;
        c++;
        return c ;
    }
}
