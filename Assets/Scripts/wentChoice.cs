using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wentChoice : MonoBehaviour {
   public void Toroad()//呼び出されるとLoaddataに移動
    {
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("Loaddata");
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
