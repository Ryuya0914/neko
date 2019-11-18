using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // スクリプト***********************************************************
    Manager_P _manager;
    // パラメータ***********************************************************
    int MaxLife;                // HPの最大値
    int NowLife;                // 現在のHP
    // *********************************************************************


    void Start() {
        _manager = GetComponent<Manager_P>();
        MaxLife = _manager.Get_Life;            // 最大HPを取得
        NowLife = MaxLife;                      // HPを取得
    }
    
    // HPを１回復
    public int IncreaseHP() {
        if(NowLife < MaxLife)   // 最大HPより小さい場合は１足す
            NowLife++;
        return NowLife;         // 現在のHPを返す
    }

    // HPを１減少
    public int DecreaseHP() {
        return --NowLife;       // HPを１減らして返す
    }

}
