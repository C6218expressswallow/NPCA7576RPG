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
                        return "save data has breaked!";
                    }
                    if (hpdata % hpshash != hphash)
                    {
                        PlayerPrefs.DeleteAll();
                        return "save data has breaked!";
                    }
                    if (leveldata % 101 != 0)
                    {
                        PlayerPrefs.DeleteAll();
                        return "save data has breaked!";
                    }
                    leveldata = leveldata % 101;
                    datamanagement.Saver(hpdata, leveldata);
                    named = PlayerPrefs.GetString("name" + num);
                }
            }
        }
        return "nothing";//データがない場合はfalseを返す
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
        PlayerPrefs.SetInt("hp" + num, (datamanagement.hitpoint)*101);
        PlayerPrefs.SetInt("hph" + num, ((datamanagement.hitpoint*101) % hpshash));
        PlayerPrefs.SetInt("level" + num, (datamanagement.level));
        PlayerPrefs.SetInt("levelh" + num, ((datamanagement.level) % levelshash));
    }
}
