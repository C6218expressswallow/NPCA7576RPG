using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Save : MonoBehaviour {
    private int leveldata;//レベルデータ
    private int levelhash;//ハッシュ
    private int hpdata;//HP
    private int hphash;//ハッシュ
    private int levelshash = 11;//ハッシュキーは11
    private int hpshash = 23;
    private int levelhashplus = 101;//強化
    public Datamanagement datamanagement;
    public string named;
	public string Load(int num)//num番目のセーブデータを読み込む
    {
        if (PlayerPrefs.HasKey("hp"+num))//もし"hp(num)"というデータが存在したら
        {
            if (PlayerPrefs.HasKey("level" + num))//もし"level(num)"というデータが存在したら
            {
                if (PlayerPrefs.HasKey("name" + num))
                {
                    leveldata = PlayerPrefs.GetInt("level" + num);
                    hpdata = PlayerPrefs.GetInt("hp" + num);
                    levelhash = PlayerPrefs.GetInt("levelh" + num);
                    hphash = PlayerPrefs.GetInt("hph" + num);
                    if (leveldata % levelshash != levelhash)
                    {
                        PlayerPrefs.DeleteAll();//もし改変されていたらすべてのデータを削除する
                        return "save data had breaked!";
                    }
                    if (hpdata % hpshash != hphash)
                    {
                        PlayerPrefs.DeleteAll();
                        return "save data had breaked!";
                    }
                    if (leveldata % levelhashplus != 0)
                    {
                        PlayerPrefs.DeleteAll();
                        return "save data had breaked!";
                    }
                    leveldata = leveldata % levelhashplus;
                    datamanagement.Saver(hpdata, leveldata);
                    named = PlayerPrefs.GetString("name" + num);
                    return named;
                }
            }
        }
        return "save data is nothing";//データがない場合はfalseを返す
    }
    public void Saved(int num,string names)
    {
        if (PlayerPrefs.HasKey("name" + num))
        {
            PlayerPrefs.DeleteKey("name" + num);
        }
        if (PlayerPrefs.HasKey("hp" + num))
        {
            PlayerPrefs.DeleteKey("hp" + num);
            PlayerPrefs.DeleteKey("hph" + num);
        }
        if (PlayerPrefs.HasKey("level" + num))
        {
            PlayerPrefs.DeleteKey("level" + num);
            PlayerPrefs.DeleteKey("levelh" + num);
        }
        PlayerPrefs.SetString("name" + num, names);
        PlayerPrefs.SetInt("hp" + num, (datamanagement.hitpoint)*levelhashplus);
        int hphaser = (datamanagement.hitpoint * levelhashplus) % hpshash;
        PlayerPrefs.SetInt("hph" + num, hphaser);
        PlayerPrefs.SetInt("level" + num, (datamanagement.level));
        PlayerPrefs.SetInt("levelh" + num, ((datamanagement.level) % levelshash));
    }
}
