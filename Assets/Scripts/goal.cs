using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour {
    public TextAsset newstage;
    public GameObject logiventor;
    private eventmanager logivent;
    private int ans;
    public GameObject builder;
    public GameObject player;
    private build built;
    private void Start()
    {
        logiventor = GameObject.FindGameObjectWithTag("event");
        logivent = logiventor.GetComponent<eventmanager>();
        player = GameObject.FindGameObjectWithTag("Trejar");
        if (player == null)
        {
            Debug.Log("error!");
        }
        builder = GameObject.FindGameObjectWithTag("builder");
        built = builder.GetComponent<build>();
    }//参照するスクリプトを開く
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trejar")
        {
            Debug.Log("hit the player!");
            logivent.Log("go to next floor?");
        }
    }//プレイヤーが触れたら、ログを出す。
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trejar")
        {
            
            ans = logivent.Which();
            if (ans == 1)
            {
               GameObject[] game= GameObject.FindGameObjectsWithTag("tikei");
                foreach(var dest in game)
                {
                    Destroy(dest);

                }
                player.transform.position = new Vector3(1, -1, 0);
                built.Stagebuild(newstage.text);
            }
        }
    }//プレイヤーが触れている間、選択ログを出し続ける
}
