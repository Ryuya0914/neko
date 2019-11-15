using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    // スクリプト ***************************************************
    Manager_P _manager;
    Move _move;
    //Audio_P _audio;
    //Animator_P _animator;
    //***************************************************************
    void Start() {
        _manager = GetComponentInParent<Manager_P>();
        _move = GetComponentInParent<Move>();
        //_audio = transform.parent.Find("Audio_P").GetComponent<Audio_P>();
        //_animator = GetComponentInParent<Animator_P>();
    }

    //地面に当たった時の判定
    void OnCollisionStay2D(Collision2D col) {
        if(col.gameObject.tag == "Ground") { //タグの確認
            if(!_manager.Flag_onGround) {  //地面から離れているか確認
                ////SE再生
                //_audio.Audio_Land();

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

        } 
    }

}
