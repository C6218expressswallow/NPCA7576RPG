using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanagement : MonoBehaviour {
    public int hitpoint;
    public int level;
    public bool flug1;
    public void Saver(int hp,int Lv)
    {
        hitpoint = hp;
        level = Lv;
    }
}
