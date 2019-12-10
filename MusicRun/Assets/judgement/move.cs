using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move : MonoBehaviour
{
    [SerializeField, Header("mane引継ぎ用")] mane mane;
    [SerializeField, Header("カラー省略用")] SpriteRenderer Sp;
    [SerializeField, Header("BGM入れる")] AudioSource BGM;
    [SerializeField, Header("判定ポイント")] Transform Point;
    [SerializeField, Header("判定表示用テキスト")] Text JugdeText;
    [SerializeField, Header("ノーツの判定切り替え")] bool switching = true;
    [SerializeField, Header("ノーツの合計数")] int count;
    [SerializeField, Header("maneのノーツ番号入れてね")] float interval;
    [SerializeField, Header("判定ポイント過ぎた後の距離")] float distance;
    void Update()
    {
        if (switching) Move();//move実行位置
        else Tinsel();//見掛け倒し用
    }



    //判定の存在する右側ノーツ用
    void Move()
    {
        Recycle();
        //BGMとintervalを比較して差分で動かす用
        transform.position = new Vector2((interval - BGM.time) * 10 + Point.position.x, Point.position.y);
    }



    //判定の存在しない見掛け倒しの左側ノーツ用
    void Tinsel()
    {
        Recycle();
        //BGMとintervalを比較して差分で動かす用
        transform.position = new Vector2((interval - BGM.time) * -10 + Point.position.x, Point.position.y);
    }


    //ノーツの使いまわし用
    void Recycle()
    {
        
        //BGMの再生時間と各ノーツの持っている値を比較
        if (BGM.time > interval + distance)
        {
            if (mane.Recast && switching)
            {
                //何か呼ぶならここ
            }
            //ノーツ使いまわし用
            interval += count;
            //透明になっていろノーツを元に戻すよう
            Sp.material.color = Color.white;
            //判定音の都合上必要
            mane.Vanish_Notes = true;
            mane.NullText = true;
        }

    }
}
