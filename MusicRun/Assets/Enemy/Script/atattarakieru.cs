using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atattarakieru : MonoBehaviour
{
    ParticleSystem notes;
    Transform child;
    void Start()
    {
        notes = gameObject.GetComponentInParent<ParticleSystem>();
        notes.Stop();
    }
    public void setactive_f()
    {
        notes.Play();
        gameObject.SetActive(false);
    }


}
