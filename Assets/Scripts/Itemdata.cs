using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu]
public class Itemdata : MonoBehaviour {
    public Image ItemChip;//アイテム画像
    public string infomation;//説明
    public int many;//いくつ所持しているか
    public int heal;//使用時のHP回復量
    public int Damage;//使用時の敵へのダメージ
    public int Condision;//特殊効果フラグ
    public bool Checker()
    {
        return !(many <= 0);//アイテムを所持しているか（イベントフラグに使用？）
    }
}
