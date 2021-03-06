﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_P : MonoBehaviour {
    // スクリプト **********************************************************
    Manager_P _manager;
    Move _move;
    mane _mane;
    Score _score;
    Life _life;
    //Audio_P _audio;
    //Animator_P _animator;
    // パラメータ **********************************************************
    bool AllMoveFlag = false;                   //移動できるかのフラグをまとめたもの
    float Angle_Range;                          //重力移動できる角度の範囲
    SpriteRenderer spriteRenderer;              // 矢印の表示と非表示を切り替えるときに使う
    //  ********************************************************************

    void Start() {
        _manager = GetComponentInParent<Manager_P>();
        _move = GetComponentInParent<Move>();
        _mane = GameObject.Find("mane").GetComponent<mane>();
        _score = GameObject.Find("GameRoot").GetComponent<Score>();
        _life = GetComponentInParent<Life>();
        //_audio = transform.parent.Find("Audio_P").GetComponent<Audio_P>();
        //_animator = transform.parent.GetComponent<Animator_P>();
        Angle_Range = _manager.Get_angle_Arrow / 2f;
        spriteRenderer = GetComponent<SpriteRenderer>();

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
            // リズム判定を獲得
            int judgeNum = _mane.Return_Judge();
            _manager.Judge_GetSet = judgeNum;   // managerのほうに設定
            switch(judgeNum) {      // 移動時にスコア加算
                case -1:                 // Miss
                    _life.DecreaseHP();     // Lifeを減らす
                    break;
                case 0:                 // Miss
                    _life.DecreaseHP();     // Lifeを減らす
                    break;
                case 1:                 // Good
                    _score.AddScore(5);     // Score獲得
                    break;
                case 2:                 // Parfect
                    _score.AddScore(10);    // Score獲得
                    break;
            }
            //移動するメソッドを呼び出す
            _move.GMove(_manager.GetAngle_PlayerMouse());
            _manager.MoveStateChange();
            ////音を再生
            //_audio.Audio_Jump();
            ////アニメーションを再生
            //_animator.Animation_Gmove();
        }
    }

    //矢印の位置と角度を更新する
    void Arrow_Update() {
        if(AllMoveFlag) { //重力移動出来るとき
            //角度を取得(弧度法から度数法に変換)
            float deg = _manager.GetAngle_PlayerMouse() * Mathf.Rad2Deg;
            if(deg < 0) deg += 360;
            //矢印を回転
            if(transform.parent.localScale.x > 0)
                transform.rotation = Quaternion.Euler(0, 0, deg + 90);
            else
                transform.rotation = Quaternion.Euler(0, 0, deg - 90);
            // 矢印を表示する
            spriteRenderer.enabled = true;

        } else {
            // 矢印を非表示にする
            spriteRenderer.enabled = false;
        }

    }


}
