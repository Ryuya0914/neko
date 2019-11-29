using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_generator : MonoBehaviour
{
    [SerializeField] GameObject[] s_pre = new GameObject[12];//ステージのプレハブ
    GameObject[] go = new GameObject[12];
    float[] s_pos = { 0, 36, 72, 108, 144, 180, 216, 252, 288, 324, 360, 396 };//ステージのポジション
    float[] kyori = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Start()
    {
        //てきとーに配列混ぜてる
        GameObject x;
        for (int i = 1; i < 11; i++)
        {
            int rnd = Random.Range(1, 11);
            x = s_pre[i];
            s_pre[i] = s_pre[rnd];
            s_pre[rnd] = x;
        }
        //ステージ配置
        for (int i = 0; i < 12; i++)
        {
            go[i] = Instantiate(s_pre[i], new Vector2(s_pos[i], 0), Quaternion.identity);
        }
    }

    void Update()
    {

        for (int i = 0; i < 12; i++)
        {
            kyori[i] = Mathf.Abs(s_pos[i] - gameObject.transform.position.x);
        }

        for (int i = 0; i < 12; i++)
        {
            if (kyori[i] >= 40)
            {
                go[i].SetActive(false);
            }
            else
            {
                go[i].SetActive(true);
            }
        }
    }
}
