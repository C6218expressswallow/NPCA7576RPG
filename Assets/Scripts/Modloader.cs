using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Modloader : MonoBehaviour {
    string path;
	// Use this for initialization
	void Start () {
        path = Application.dataPath + "/../../Stage";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.txt");
        Debug.Log("load data!");
        foreach(FileInfo f in info)
        {
            Debug.Log(f.Name);
        }
        Debug.Log("have loaded data!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
