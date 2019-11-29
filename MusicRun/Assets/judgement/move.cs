using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class move : MonoBehaviour
{
    [SerializeField,Header("判定ポイント")] GameObject Target;
    [SerializeField,Header("判定表示用テキスト")] Text judge;
    [SerializeField,Header("BGMのaudiosource入れるやつ")] AudioSource BGM;
    [SerializeField,Header("maneのノーツ番号入れてね")] float interval;
    [SerializeField,Header("maneをgetcomponentする用")]GameObject l,p;
    [SerializeField, Header("判定ポイント過ぎた後の距離")] float distance;
    [SerializeField, Header("ノーツの合計数")] int count;
    [SerializeField] float speed;
    mane mane;
    Life life;
    void Start()
    {
        mane = l.GetComponent<mane>();//mane引継ぎ用
        life=p.GetComponent<Life>();
    }

    void Update()
    {
        Move();//move実行位置
        
    }
    //ノーツ移動用メソッド
    void Move()
    {
        //BGMの再生時間と各ノーツの持っている値を比較
        if (BGM.time > interval + distance)
        {
            if (mane.Recast)
            {
                judge.text = "Miss";//判定テキスト変更
                life.DecreaseHP();
            }
            //ノーツ使いまわし用
            interval += count;
            //透明になっていろノーツを元に戻すよう
            this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        }
        //BGMとintervalを比較して差分で動かす用
        transform.position = new Vector2((interval - BGM.time) * 10 + Target.transform.position.x, -8);
    }
}
