using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventmanager : MonoBehaviour {
    public Text text;
    public Image image;
    public int flug = 0;
	// Use this for initialization
	void Start () {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
	}
    public void Log(string s)
    {
        text.gameObject.SetActive(true);
        image.gameObject.SetActive(true);
        text.text = s;
    }
    public int Which(string a="Yes",string b="No")
    {
        flug = 0;
        return flug;
    }
}
