using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
    public Datamanagement datamanagement;
	public bool Load(int num)//num番目のセーブデータを読み込む
    {
        if (PlayerPrefs.HasKey("hp"+num))//もし"hp(num)"というデータが存在したら
        {
            if (PlayerPrefs.HasKey("level" + num))//もし"level(num)"というデータが存在したら
            {
                datamanagement.Saver(PlayerPrefs.GetInt("hp" + num), PlayerPrefs.GetInt("level" + num));//ロードする
                return true;
            }
        }
        return false;//データがない場合はfalseを返す
    }
    public void Saved(int num)
    {
        if (PlayerPrefs.HasKey("hp" + num))
        {
            PlayerPrefs.DeleteKey("hp" + num);
        }
        if (PlayerPrefs.HasKey("level" + num))
        {
            PlayerPrefs.DeleteKey("level" + num);
        }
        PlayerPrefs.SetInt("hp" + num, datamanagement.hitpoint);
        PlayerPrefs.SetInt("level" + num, datamanagement.level);
    }
}
