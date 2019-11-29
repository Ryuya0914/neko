using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
//変数まとめたやつ
class Summary
{

    [Header("判定後のノーツの色（透明）")] public Color Transparent;//透明の色
    [Header("一度押した後再判定するまでの時間")] public float Recasttime;//再判定までの時間
    [Header("ノーツの判定される距離（判定ポイント基準）")] public float Judge_Distance;//判定距離
    [Header("判定ポイントからのパーフェクト範囲")] public float Perfect_Distance;//パーフェクトの範囲
    [Header("判定ポイントからのグッド範囲")] public float Good_Distance;//グッドの範囲

}
[System.Serializable]
class Item
{
    [Header("判定ポイント")]public GameObject Target;
    [Header("ノーツその1")]public GameObject A1;
    [Header("ノーツその2")]public GameObject A2;
    [Header("ノーツその3")]public GameObject A3;
    [Header("判定表示用テキスト")]public Text JugdeText;
}
public class mane : MonoBehaviour
{
    [SerializeField,Header("変数まとめたもの")] Summary Summary;
    [SerializeField,Header("オブジェクトまとめたもの")] Item Item;
    [HideInInspector] public bool Recast = true;
    float A, B, C, Max;
    //矢印と判定位置の距離の差のやつ
    void Distance()
    {
        A = Mathf.Abs(Item.A1.transform.position.x - Item.Target.transform.position.x);
        B = Mathf.Abs(Item.A2.transform.position.x - Item.Target.transform.position.x);
        C = Mathf.Abs(Item.A3.transform.position.x - Item.Target.transform.position.x);
        Max = A;
        if (B < Max) Max = B;
        if (C < Max) Max = C;
    }
    //矢印が消えるやつ
    void Vanish()
    {
        if (Max <= Summary.Judge_Distance)
        {
            if (A == Max) Item.A1.GetComponent<SpriteRenderer>().material.color =Summary.Transparent;
            else if (B == Max) Item.A2.GetComponent<SpriteRenderer>().material.color = Summary.Transparent;
            else Item.A3.GetComponent<SpriteRenderer>().material.color = Summary.Transparent;
        }
    }
    //判定のやつ
    int Jugde()
    {
        int Ret=-1;
        if (Max < Summary.Judge_Distance)
        {
            if (Max < Summary.Perfect_Distance)
            {
                Ret = 2;
                Item.JugdeText.text = "Perfect";
            }
            else if (Max < Summary.Good_Distance)
            {
                Ret = 1;
                Item.JugdeText.text = "Good";
            }
            else
            {
                Ret = 0;
                Item.JugdeText.text = "Miss";
            }
        }
        return Ret;
    }
    //再判定用のフラグを戻すやつ
    void RecastReset()
    {
        Recast = true;
    }
    //クリックか何かしたら実行するやつ
    public int Return_Judge()
    {
        int Ret = -1;
        Distance();
        Vanish();
        if (Recast)
        {
            Ret=Jugde();
            Recast = false;
            Invoke("RecastReset", Summary.Recasttime);
        }
        else Item.JugdeText.text = "Miss";
        return Ret;
    }
}
