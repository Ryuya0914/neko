using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    // スクリプト***********************************************************
    Manager_P _manager;
    // パラメータ***********************************************************
    int MaxLife;                // HPの最大値
    int NowLife;                // 現在のHP
    // UI ******************************************************************
    Text _lifeText;             // Life表示用のText

    void Start() {
        _manager = GetComponent<Manager_P>();
        MaxLife = _manager.Get_Life;            // 最大HPを取得
        NowLife = MaxLife;                      // HPを取得
        _lifeText = GameObject.Find("LifeText").GetComponent<Text>();
    }
    
    // HPを１回復
    public void IncreaseHP() {
        if(NowLife < MaxLife)   // 最大HPより小さい場合は１足す
            NowLife++;

        // UIを更新
        UpdateLifeText();
    }

    // HPを１減少
    public void DecreaseHP() {
        // HPを１減らす
        NowLife--;
        // UIを更新
        UpdateLifeText();
        // HPが0になったら
        

    }

    void UpdateLifeText() {
        _lifeText.text = "LIFE：" + NowLife.ToString("0");
    }

}
