using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
//変数まとめたやつ
class Summary
{

    [Header("判定後のノーツの色（透明）")] public Color Transparent;
    [Header("一度押した後再判定するまでの時間"),Range(0.0f,0.6f)] public float Recasttime;
    [Header("ノーツの判定される距離（判定ポイント基準）"),Range(2,4)] public float Judge_Distance;
    [Header("判定ポイントからのパーフェクト範囲"),Range(0.2f,0.4f)] public float Perfect_Distance;
    [Header("判定ポイントからのグッド範囲"),Range(1,3)] public float Good_Distance;
    [Header("判定ポイントからのミス範囲"),Range(0.01f,0.15f)] public float Miss_Distance;
    [Header("判定テキストリセットまでの時間"),Range(0.2f,0.4f)] public float Reset_Time;
}


[System.Serializable]
class Item
{
    [Header("ノーツ")] public Transform[] Notes;
    [Header("フェイクノーツ")] public Transform[] Fake_Notes;
    [Header("ノーツカラー")] public SpriteRenderer[] Notes_C;
    [Header("フェイクノーツカラー")] public SpriteRenderer[] Fake_Notes_C;
    [Header("判定表示用テキスト")]public Text JugdeText;
    [Header("判定ポイント")] public Transform Point;
    [Header("パーフェクトエフェクト")] public GameObject Perfect_Efe;
    [Header("判定音")] public AudioClip[] Sound_Effect;
}


public class mane : MonoBehaviour
{
    [SerializeField, Header("変数まとめたもの")] Summary Summary;
    [SerializeField, Header("オブジェクトまとめたもの")] Item Item;
    //再判定フラグ
    [HideInInspector] public bool Recast = true;
    //判定テキストリセットフラグ
    [HideInInspector] public bool NullText = false;
    //ノーツが透明か判断するフラグ
    [HideInInspector] public bool Vanish_Notes = true;
    //各ノーツの距離比較用
    float Notes_A, Notes_B, Notes_C, Distance_Min;
    

    void Update()
    {
        //各ノーツの距離計算
        Distance();

        //ノーツをスルーした時の処理
        if (Distance_Min < Summary.Miss_Distance)
        {
            if (Vanish_Notes)
            {
                Item.JugdeText.text = "Miss";
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = Item.Sound_Effect[2];
                audio.Play();
            }
            AA();
        }


        //判定テキストリセットのタイミング調整
        if (NullText) Invoke("Null_Text", Summary.Reset_Time);

        //試し用
        if (Input.GetKeyDown(KeyCode.Return)) Return_Judge();

    }

    //矢印と判定位置の距離の差のやつ
    void Distance()
    {
        Notes_A = Mathf.Abs(Item.Notes[0].position.x - Item.Point.position.x);
        Notes_B = Mathf.Abs(Item.Notes[1].position.x - Item.Point.position.x);
        Notes_C = Mathf.Abs(Item.Notes[2].position.x - Item.Point.position.x);
        Distance_Min = Notes_A;
        if (Notes_B < Distance_Min) Distance_Min = Notes_B;
        if (Notes_C < Distance_Min) Distance_Min = Notes_C;
    }


    //矢印が消えるやつ
    void Vanish()
    {
        
        Vanish_Notes = false;
        if (Distance_Min <= Summary.Judge_Distance)
        {
            if (Notes_A == Distance_Min)
            {
                Item.Notes_C[0].material.color = Summary.Transparent;
                Item.Fake_Notes_C[0].material.color = Summary.Transparent;

            }
            else if (Notes_B == Distance_Min)
            {
                Item.Notes_C[1].material.color = Summary.Transparent;
                Item.Fake_Notes_C[1].material.color = Summary.Transparent;

            }
            else
            {
                Item.Notes_C[2].material.color = Summary.Transparent;
                Item.Fake_Notes_C[2].material.color = Summary.Transparent;

            }
        }
    }
    

    void AA()
    {
        if (Distance_Min <= Summary.Judge_Distance)
        {
            if (Notes_A == Distance_Min)
            {
                if (!Vanish_Notes && Item.Notes_C[0].material.color == Color.white)
                {
                    Item.JugdeText.text = "miss";
                }

            }
            else if (Notes_B == Distance_Min)
            {
                if (!Vanish_Notes && Item.Notes_C[1].material.color == Color.white)
                {
                    Item.JugdeText.text = "miss";
                }

            }
            else
            {
                if (!Vanish_Notes && Item.Notes_C[2].material.color == Color.white)
                {
                    Item.JugdeText.text = "miss";
                }
            }
        }

    }

    //判定のやつ
    int Jugde()
    {
        AudioSource audio = GetComponent<AudioSource>();
        int Ret = -1;
        if (Distance_Min < Summary.Judge_Distance)
        {
            if (Distance_Min < Summary.Perfect_Distance)
            {
                Ret = 2;
                Item.JugdeText.text = "Perfect";
                audio.clip = Item.Sound_Effect[0];
                audio.Play();
                Item.Perfect_Efe.SetActive(true);
            }
            else if (Distance_Min < Summary.Good_Distance)
            {
                Ret = 1;
                Item.JugdeText.text = "Good";
                audio.clip = Item.Sound_Effect[1];
                audio.Play();

            }
            else
            {
                Ret = 0;
                Item.JugdeText.text = "Miss";
                audio.clip = Item.Sound_Effect[2];
                audio.Play();
            }
        }
        return Ret;
    }


    //再判定用のフラグを戻すやつ
    void RecastReset()
    {
        Recast = true;
        Item.Perfect_Efe.SetActive(false);

    }

    //判定テキストリセットタイミング調整用
    public void Null_Text()
    {
        Item.JugdeText.text = null;
        NullText = false;

    }


    //クリックか何かしたら実行するやつ
    public int Return_Judge()
    {
        int Ret = -1;
        Vanish();
        if (Recast)
        {
            Ret = Jugde();
            Recast = false;
            Invoke("RecastReset", Summary.Recasttime);
        }
        //else
        //{
        //    Item.JugdeText.text = "Miss";
        //}
        return Ret;
    }

}
