using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float speed = 0.01f;
    float stoptimer = 0.0f;
    private float begspeed;
    private bool heel = false, poison = false;
    public long HP = 100;
    public Text text;
    public long HPmax = 100;
    float onetime = 0;
	// Use this for initialization
	void Start () {
        begspeed = speed;
	}
    
    // Update is called once per frame
    void FixedUpdate () {
        onetime += Time.deltaTime;//経過時間の取得
        if (onetime > 1)
        {
            onetime = 0;
            if (heel)
            {
                HP+=3;//体力回復
                if (HP > HPmax)
                {
                    HP = HPmax;//HPが上限まで達していれば、回復を止める
                }
            }
            if (poison)
            {
                HP-=5;//ダメージ
               
            }
            if (HP < 10)
            {
                text.color = Color.red;//HPを赤にする
            }
            else if (HP < 20)
            {
                text.color = Color.yellow;//HPを黄色にする
            }
            else
            {
                text.color = Color.green;//HPを青にする
            }
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene("game over");//ゲームオーバー処理
        }
        text.text = "HP:" + HP;
        if (stoptimer >= 0)
        {
            stoptimer -= Time.deltaTime;
            if (stoptimer <= 0)
            {
                speed = begspeed;//スピードを元に戻す
            }
        }
        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))//上へ移動
        {
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))//下へ移動
        {
            transform.position += new Vector3(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))//右へ移動
        {
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))//左へ移動
        {
            transform.position += new Vector3(-speed, 0, 0);
        }
        transform.rotation = Quaternion.identity;
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        tikei map = col.GetComponent<tikei>();//衝突したものが何か判定する
        if (map != null)//地形オブジェクトなら
        {
            int a = map.breaking();//壊せるか（壊す）
            if (a == 1)
            {
                stoptimer = 0.5f;
                speed = 0;
            }//破壊時のアニメーションの間の時間を稼ぐ
            if (a == 2)
            {
                heel = true;
            }//回復スポットに入った
            if (a == 3)
            {
                poison = true;
            }//ダメージスポットに入った
        }
    }
    private void OnTriggerExit2D(Collider2D col)//外に出たとき
    {
        tikei map = col.GetComponent<tikei>();
        if (map == false)
        {
            return;
        }
        int a = map.type;
        if (a == 2)
        {
            heel = false;
        }
        if (a == 3)
        {
            poison = false;
        }
    }
}
