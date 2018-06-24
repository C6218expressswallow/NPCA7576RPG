using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class build : MonoBehaviour {
    public GameObject fall01;
    public GameObject lake01;
    public GameObject poison01;
    public GameObject breaking01;
    public GameObject gate01;
    Dictionary<char, GameObject> map;
    public TextAsset text;
    public TextAsset nextstage;
	void Start () {
        map = new Dictionary<char, GameObject>()
        {
            {'f',fall01 },//'f'を壁オブジェクトに関連付ける
            {'l',lake01 },
            {'\n',null },
            {'p',poison01 },
            {'b',breaking01 },
            {'g',gate01 },
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
