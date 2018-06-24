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
    public GameObject target;
    public int breaking()
    {
        if (type == 1)
        {
            Debug.Log("collider!");
            Instantiate (target, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        return type;
    }
}
