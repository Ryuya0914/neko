using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    static float _Score;                    // スコア


    void Start()
    {
        _Score = 0;                     // ゲーム開始時にスコアを0にする
    }

    // スコアを加算したり、渡したりする
    public float Get_Score { get { return _Score; } }

    // スコアを加算する
    public void AddScore(float s) { _Score += s; }

}
