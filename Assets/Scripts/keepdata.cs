using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepdata : MonoBehaviour {
    private void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(this.gameObject);
    }
    public string datasname;

}
