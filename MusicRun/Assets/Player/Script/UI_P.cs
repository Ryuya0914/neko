using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_P : MonoBehaviour {
    // スクリプト **********************************************************
    Manager_P _manager;
    Move _move;
    //Audio_P _audio;
    //Animator_P _animator;
    // パラメータ **********************************************************
    bool AllMoveFlag = false;                   //移動できるかのフラグをまとめたもの
    float Angle_Range;                          //重力移動できる角度の範囲
    //  ********************************************************************

    void Start() {
        _manager = GetComponentInParent<Manager_P>();
        _move = GetComponentInParent<Move>();
        //_audio = transform.parent.Find("Audio_P").GetComponent<Audio_P>();
        //_animator = transform.parent.GetComponent<Animator_P>();
        Angle_Range = _manager.Get_angle_Arrow / 2f;

    }
    void Update() {
        //フラグの更新
        AllMoveFlag = (_manager.Flag_click && _manager.Flag_onGround);

        //移動方向矢印の位置更新
        Arrow_Update();

        //左クリックを受け付ける
        if(Input.GetMouseButtonDown(0)) {
            LeftClick();
        }


    }

    //左クリックをした際に移動できるかどうか確認し、出来たら移動
    void LeftClick() {
        //移動可能フラグが立っているか確認
        if(AllMoveFlag) {
            //移動するメソッドを呼び出す
            _move.GMove();
            ////音を再生
            //_audio.Audio_Jump();
            ////アニメーションを再生
            //_animator.Animation_Gmove();
        }
    }

    //矢印の位置と角度を更新する
    void Arrow_Update() {
        if(AllMoveFlag) { //重力移動出来るとき
            //角度を取得
            float deg = _manager.GetAngle_PlayerMouse();
            //矢印を回転
            if(transform.parent.localScale.x > 0)
                transform.rotation = Quaternion.Euler(0, 0, deg);
            else
                transform.rotation = Quaternion.Euler(0, 0, deg + 180);
        }

    }


}
