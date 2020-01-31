using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ranking : MonoBehaviour
{
    [SerializeField]float[] rank;
    [SerializeField] Text[] text;
    void Start()
    {
        for(int x = 0; x <= 5; x++) rank[x] = PlayerPrefs.GetFloat("score" + x);


        Array.Sort(rank);

        for (int a = 0; a < 5; a++)
        {
            StartCoroutine(Counter(a, 2f));
        }

    }



    IEnumerator Counter(int a, float c)
    {
        float time = Time.deltaTime;
        float end = time + c;
        do
        {
            float Time_Rate = (Time.time - time) / c;
            float Update_Value = (float)((rank[5 - a]) * Time_Rate + time);
            text[a].text = Update_Value.ToString();
            yield return null;
        } while (Time.time < end);
        text[a].text = rank[5 - a].ToString();
        
        if (rank[5 - a] == PlayerPrefs.GetFloat("score" + 0)) text[a].color = Color.red;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) for (int z = 0; z <= 5; z++) rank[z] = 0;


        if (Input.GetMouseButtonDown(0))
        {
            for (int z = 0; z <= 5; z++) PlayerPrefs.SetFloat("score" + z, rank[z]);
            Invoke("Scene", 1);
        }

    }
    void Scene()
    {
        SceneManager.LoadScene("Title");
    }
}
