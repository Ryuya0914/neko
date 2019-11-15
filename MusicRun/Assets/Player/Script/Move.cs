﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    // スクリプト ************************************************
    Manager_P manager;
    // *****************************************************
    float speed = 0;                // 自機の移動速度
    Rigidbody2D rigid2d;            // 物理演算してくれるやつ
    Vector3 firstScale;             // 初期サイズ
    float Angle_Range;              // 重力移動できる角度の範囲
    // ***********************************************************

    void Start() {
        manager = GetComponent<Manager_P>();
        rigid2d = GetComponent<Rigidbody2D>();
        //パラメータの取得
        speed = manager.Get_gMove_Speed;
        firstScale = transform.localScale;
        Angle_Range = manager.Get_angle_Arrow / 2;
    }

    //プレイヤーをマウスカーソルの方向に飛ばす
    public void GMove() {
        //        float NowAngle = transform.localEulerAngles.z;

        //地面接触フラグを消す
        manager.Flag_onGround = false;

        //自機からマウスカーソルのベクトル
        Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //角度(ラジアン)
        float rad = Mathf.Atan2(vec.y, vec.x);
        //角度(度数法)
        float deg = Mathf.Rad2Deg * rad;
        //角度に制限を掛ける
        //        if (deg >= NowAngle + Angle_Range || deg <= -90) deg = NowAngle + Angle_Range;
        //        if (deg <= NowAngle - Angle_Range && deg >= -90) deg = NowAngle - Angle_Range;
        //        //度数法で角度を制限したため角度(ラジアン)を修正
        //        rad *= Mathf.Deg2Rad;

        //それぞれの軸に与える重力の大きさと向き
        float vx = Mathf.Cos(rad) * speed;
        float vy = Mathf.Sin(rad) * speed;

        //プレイヤーの重力を変更して飛ばす
        vec = new Vector2(vx, vy);
        rigid2d.velocity = vec;
        //プレイヤーを回転
        transform.rotation = Quaternion.Euler(0, 0, deg + 90);
        Forward_Update();
    }

    //プレイヤーの向きを更新する(重力移動の時に)
    public void Forward_Update() {
        //現在の移動速度
        Vector2 vel = rigid2d.velocity;
        //移動方向に対してプレイヤーの向きを変える
        if(vel.x * vel.y > 0) {        //右上と左下に進むとき
            transform.localScale = new Vector3(firstScale.x * -1, firstScale.y, firstScale.z);
        } else if(vel.x * vel.y < 0) { //右下と左上に進むとき
            transform.localScale = new Vector3(firstScale.x, firstScale.y, firstScale.z);
        } else if(vel.y > 0) {         //真上に進むとき
            transform.localScale = new Vector3(firstScale.x, firstScale.y, firstScale.z);
        } else if(vel.y < 0) {         //真下に進むとき
            transform.localScale = new Vector3(firstScale.x * -1, firstScale.y, firstScale.z);
        }

    }


    //地面に着地する
    public void Land(ContactPoint2D hit) {
        //重力を０にする
        rigid2d.gravityScale = 0;
        //角度を地面に対して垂直にする
        Quaternion q = Quaternion.FromToRotation(transform.up, hit.normal);
        transform.rotation *= q;

        rigid2d.velocity = new Vector2(0, 0);   //静止させる

        //地面接触フラグを立てる
        manager.Flag_onGround = true;
    }

    //ダメージを受けた時
    public void Damage() {
        //重力加速度をつけて、落ちるようにする
        if(rigid2d.velocity.y > 0)
            rigid2d.gravityScale = -7f;
        else if(rigid2d.velocity.y <= 0)
            rigid2d.gravityScale = 7f;

        //移動量を半分にして反転する
        rigid2d.velocity *= -1f / 2f;
    }
}