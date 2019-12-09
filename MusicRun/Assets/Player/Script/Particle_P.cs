using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_P : MonoBehaviour
{
    // スクリプト
    Manager_P _manager;
    // パーティクル
    ParticleSystem effect;
    // フラグ エフェクトが出ているときtrue
    bool flg = false;

    void Start()
    {
        _manager = gameObject.GetComponentInParent<Manager_P>();
        effect = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // パーティクル出てるかif文
        if(flg) {
            if(_manager.Flag_onGround) {    // 地面についているとき
                effect.Stop();              // パーティクルを止める
                flg = false;
            }
        } else {
            if(!_manager.Flag_onGround) {   // 地面から離れた時
                effect.Play();              // パーティクル生成
                flg = true;
            }
        }
    }
}
