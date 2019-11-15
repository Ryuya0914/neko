using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_P : MonoBehaviour
{
    // スクリプト **********************************************************
    //Player_Move Script_Move;
    //Player_Hit Script_Hit;
    // フラグ ****************************************************
    bool Flag_Click = true;         //現在マウス入力を受け付けるならtrue
    bool Flag_OnGround = true;      //地面に接触していたらtrue
    // パラメータ **********************************************************
    float GMove_Speed = 40.0f;      //自機の移動速度
    int Life = 5;                   //ライフ
    float Distance_Arrow = 1.0f;    //プレイヤーから矢印までの距離
    float Angle_Arrow = 120f;       //重力移動できる角度
    // *********************************************************************

    // フラグの受け渡し
    public bool Flag_onGround {
        get { return this.Flag_OnGround; }
        set { this.Flag_OnGround = value; }
    }
    public bool Flag_click {
        get { return this.Flag_Click; }
        set { this.Flag_Click = value; }
    }
    //パラメータを渡す
    public float Get_gMove_Speed { get { return this.GMove_Speed; } }
    public float Get_distance_Arrow { get { return this.Distance_Arrow; } }
    public float Get_angle_Arrow { get { return this.Angle_Arrow; } }
    public int Get_Life { get { return this.Life; } }



    //プレイヤーからマウスカーソルまでの角度を求める
    public float GetAngle_PlayerMouse() {
        float deg = 0;

        //自機からマウスカーソルのベクトル
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //角度(ラジアン)
        float rad = Mathf.Atan2(vec.y, vec.x);

        //角度(度数法)
        deg = Mathf.Rad2Deg * rad;

        //      //角度に制限を掛ける
        //      if (deg >= StartLocalVec + Angle_Range || deg <= -90) deg = StartLocalVec + Angle_Range;
        //      if (deg <= StartLocalVec - Angle_Range && deg >= -90) deg = StartLocalVec - Angle_Range;



        return deg;
    }
}
