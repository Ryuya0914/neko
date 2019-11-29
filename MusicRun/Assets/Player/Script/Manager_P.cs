using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_P : MonoBehaviour
{
    // スクリプト **********************************************************
    //Player_Move Script_Move;
    //Player_Hit Script_Hit;
    // フラグ *************************************************************
    bool Flag_Click = true;         // 現在マウス入力を受け付けるならtrue
    bool Flag_OnGround = true;      // 地面に接触していたらtrue
    // パラメータ **********************************************************
    float GMove_Speed = 100.0f;     // 自機の移動速度
    int Life = 5;                   // ライフ
    float Distance_Arrow = 1.0f;    // プレイヤーから矢印までの距離
    float Angle_Arrow = 100f;       // 重力移動できる角度
    int moveState = 0;              // 重力移動する方向(上下)の切り替え用変数
    float[] angles;                 // 重力移動の制限に使う値を格納するやつ
    int _judgement = -1;            // クリック時にリズムの判定を格納する、地面ついたときに手放す
    // *********************************************************************

    void Start() {
        // 角度制限の計算
        angles = new float[2];
        angles[0] = Angle_Arrow / 2 * Mathf.Deg2Rad;
        angles[1] = (180 - Angle_Arrow / 2) * Mathf.Deg2Rad;
    }


    // フラグの受け渡し
    public bool Flag_onGround {
        get { return this.Flag_OnGround; }
        set { this.Flag_OnGround = value; }
    }
    public bool Flag_click {
        get { return this.Flag_Click; }
        set { this.Flag_Click = value; }
    }
    // パラメータの受け渡し
    public int Judge_GetSet {
        get { return this._judgement; }
        set { this._judgement = value; }
    }


    //パラメータを渡す
    public float Get_gMove_Speed { get { return this.GMove_Speed; } }
    public float Get_distance_Arrow { get { return this.Distance_Arrow; } }
    public float Get_angle_Arrow { get { return this.Angle_Arrow; } }
    public int Get_Life { get { return this.Life; } }



    //プレイヤーからマウスカーソルまでの角度を求める
    public float GetAngle_PlayerMouse() {
        //自機からマウスカーソルのベクトル
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //角度(ラジアン)
        float rad = Mathf.Atan2(vec.x, vec.y) * -1;

        //角度に制限を掛ける
        rad = AngleRegulation(rad);

        return rad;
    }

    // 角度制限
    float AngleRegulation(float rad) {
        // 計算を楽にするために[-180から180度]を[0から180度]に一度変換してからあとで戻す処置
        int x = 1;
        if(rad < 0) {
            x *= -1;
            rad *= -1;
        }

        // 上方向と下方向を切り替えるためのif文
        if(moveState == 0)          // 上方向
            rad = Mathf.Min(rad, angles[0]) * x;
        else if(moveState == 1)     // 下方向
            rad = Mathf.Max(rad, angles[1]) * x;

        return rad;
    }

    public void MoveStateChange() {
        moveState = (moveState == 0) ? 1 : 0;
    }

    // プレイヤーを動かなくする
    public void MoveStop() {
        Flag_Click = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }


}
