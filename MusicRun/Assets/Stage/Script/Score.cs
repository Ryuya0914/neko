using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    static float _Score;                    // スコア
    Text _scoreText;                        // Scoreを表示するText

    void Start()
    {
        _Score = 0;                     // ゲーム開始時にスコアを0にする
        _scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // スコアを加算したり、渡したりする
    public float Get_Score { get { return _Score; } }

    // スコアを加算する
    public void AddScore(float s) {
        _Score += s;
        _scoreText.text = "SCORE：" + _Score.ToString("00000000");
    }

}
