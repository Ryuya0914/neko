﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUserAction1()
    {
        Invoke("next", 2);

    }
    void next()
    {
        SceneManager.LoadScene("GameScene");
    }
}
