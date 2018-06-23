using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tikei : MonoBehaviour {
    public int type;
    //typeの値　種類
    //   0       壁
    //　１　　　壁（破壊可能）
    //　２　　　回復系地形
    //　３　　　ダメージ系地形
    public void breaking()
    {
        if (type == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
