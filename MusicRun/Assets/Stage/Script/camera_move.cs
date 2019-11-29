using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    int spd = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= 360)
        {
            spd = 0;
        }
        gameObject.transform.position += new Vector3(spd * Time.deltaTime, 0);
        
    }
}
