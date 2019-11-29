using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // スクリプト ***************************************************
    Manager_P _manager;
    Move _move;
    Life _life;
    Score _score;
    //Audio_P _audio;
    //Animator_P _animator;
    //***************************************************************
    void Start() {
        _manager = GetComponentInParent<Manager_P>();
        _move = GetComponentInParent<Move>();
        _life = GetComponentInParent<Life>();
        _score = GameObject.Find("GameRoot").GetComponent<Score>();
        //_audio = transform.parent.Find("Audio_P").GetComponent<Audio_P>();
        //_animator = GetComponentInParent<Animator_P>();
    }

    //地面に当たった時の判定
    void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag == "Ground") { //タグの確認
            if(!_manager.Flag_onGround) {  //地面から離れているか確認
                ////SE再生
                //_audio.Audio_Land();

                // リズム判定の評価情報を初期化
                _manager.Judge_GetSet = -1;

                //地面に立つメソッドを呼ぶ
                _move.Land(col.contacts[0]);

                ////地面に立つ
                //_animator.Animation_Land();
            }
        }
    }
    //敵にあたったときの判定
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Enemy") {
            // リズム判定を取ってくる
            int result = _manager.Judge_GetSet;
            switch(result) {        // 判定結果ごとに処理
                case 0:                 // Bad
                    _life.DecreaseHP();     // HPを減らす
                    break;
                case 1:                 // Good
                    _score.AddScore(100);   // Score獲得
                    break;
                case 2:                 // Parfect
                    _score.AddScore(200);   // Score獲得
                    break;

            }

        } else if(col.gameObject.tag == "Item") {  // Itemを取った時
            _life.IncreaseHP();                         // HPを回復する

        }
    }

}
