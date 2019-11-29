using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class camera_move : MonoBehaviour
{
    float spd = 0;
    [SerializeField] AudioSource BGM;
    // Start is called before the first frame update
    void Start()
    {
        spd = 396 / BGM.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= 396)
        {
            spd = 0;
        }
        gameObject.transform.position += new Vector3(spd * Time.deltaTime, 0);
        
    }
}
