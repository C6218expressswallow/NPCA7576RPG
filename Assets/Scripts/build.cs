using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour {
    public GameObject fall01;//壁オブジェクト１
    public GameObject lake01;//回復オブジェクト1
    public GameObject poison01;//毒沼オブジェクト１
    public GameObject breaking01;//破壊可能オブジェクト１
    public GameObject gate01;//ゴール１
    Dictionary<char, GameObject> map;//オブジェクトと文字列を関連付けるための辞書
    public TextAsset text;//初期マップ
    public TextAsset nextstage;//ゴールに渡す次のステージ
	void Start () {
        map = new Dictionary<char, GameObject>()
        {
            {'f',fall01 },//'f'を壁オブジェクトに関連付ける
            {'l',lake01 },//'l'を回復オブジェクトに関連付ける
            {'\n',null },//'\n'(改行文字)を改行に関連付ける
            {'p',poison01 },//'p'を毒沼オブジェクトに関連付ける
            {'b',breaking01 },//'b'を破壊可能オブジェクトに関連付ける
            {'g',gate01 },//'g'をゴールに関連付ける
        };
        Stagebuild(text.text);
    }
    
    // Update is called once per frame
    void Update () {
		
	}
    public void Stagebuild(string text)
    {
        if (text == null)
        {
            Debug.Log("error!");
            return;
        }
        Vector3 originpos = new Vector3(0, 0, 0);
        Vector3 pos = originpos;
        GameObject obj = map['f'];
        foreach(char c in text)
        {
            if (c != '\n')
            {
                if (map.ContainsKey(c))
                {
                    if (c != 'g')
                    {
                        obj = Instantiate(map[c], pos, Quaternion.identity);
                        obj.name = map[c].name;
                    }
                    else
                    {
                        obj = Instantiate(map[c], pos, Quaternion.identity);
                        obj.name = map[c].name;
                        goal goal = obj.GetComponent<goal>();
                        if (goal == null)
                        {
                            Debug.Log("error!");
                        }
                        else
                        {
                            goal.newstage = nextstage;
                            
                        }
                    }
                }
                pos.x += 0.32f;
            }
            else
            {
                pos.y -= 0.32f ;
                pos.x = originpos.x;
            }
        }
    }
}
