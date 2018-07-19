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
	public bool Load(int num)//num番目のセーブデータを読み込む
    {
        if (PlayerPrefs.HasKey("hp"+num))//もし"hp(num)"というデータが存在したら
        {
            if (PlayerPrefs.HasKey("level" + num))//もし"level(num)"というデータが存在したら
            {
                leveldata = PlayerPrefs.GetInt("level" + num);
                hpdata = PlayerPrefs.GetInt("hp" + num);
                levelhash = PlayerPrefs.GetInt("levelh" + num);
                hphash = PlayerPrefs.GetInt("hph" + num);
                if (leveldata % levelshash != levelhash)
                {
                    return false;
                }
                if (hpdata % hpshash != hphash)
                {
                    return false;
                }
                datamanagement.Saver(hpdata, leveldata);
            }
        }
        return false;//データがない場合はfalseを返す
    }
    public void Saved(int num)
    {
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
        PlayerPrefs.SetInt("hp" + num, datamanagement.hitpoint);
        PlayerPrefs.SetInt("hph" + num, (datamanagement.hitpoint % hpshash));
        PlayerPrefs.SetInt("level" + num, datamanagement.level);
        PlayerPrefs.SetInt("levelh" + num, (datamanagement.level % levelshash));
    }
}
