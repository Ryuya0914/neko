using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_P : MonoBehaviour
{
    // パラメータ **********************************************************
    [SerializeField] AudioClip[] audioClips; //再生する音 0,ジャンプ 1,ジャンプ 2,着地 3,歩く 4,ダメージ
    AudioSource _audio;
    // *********************************************************************

    void Start() {
        _audio = GetComponent<AudioSource>();
    }

    //ジャンプ音
    public void Audio_Jump() {
        _audio.PlayOneShot(audioClips[0]);
    }
    //着地音
    public void Audio_Land() {
        _audio.PlayOneShot(audioClips[2]);
    }
    //歩く
    public void Audio_Walk() {
        _audio.PlayOneShot(audioClips[3]);
    }
    //ダメージ
    public void Audio_Damage() {
        _audio.PlayOneShot(audioClips[4]);
    }
}
