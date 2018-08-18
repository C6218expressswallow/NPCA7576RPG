using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Modloader : MonoBehaviour {
    string path;
    public FileInfo[] stageinfo;
    public FileInfo[] iteminfo;
    public string[] stages;
    public string[] items;
	// Use this for initialization
	void Start () {
        path = Application.dataPath + "/../../Stage";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        DirectoryInfo dir = new DirectoryInfo(path);
        stageinfo = dir.GetFiles("*.txt");
        Debug.Log("load data!");
        foreach(FileInfo f in stageinfo)
        {
            StreamReader strr = new StreamReader(f.OpenRead());
            stages.CopyTo(stages = new string[stages.Length + 1], 0);
            stages[stages.Length - 1] = strr.ReadToEnd();
            Debug.Log(stages[stages.Length - 1]);
        }
        Debug.Log("have loaded data!");
        path = Application.dataPath + "/../../Item";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        dir = new DirectoryInfo(path);
        iteminfo = dir.GetFiles("*.txt");
        Debug.Log("road items!");
	}
}
