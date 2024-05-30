using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class Whistle : MonoBehaviour
{

    private AudioSource whistleSource;

    public Boolean whistleBool;

    // Start is called before the first frame update
    void Start()
    {
        whistleSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setWhistleTrue()
    {
        whistleBool = true;
    }

    public void setWhistleFalse()
    {
        whistleBool = false;
    }

    public void playWhistle()
    {
        if (whistleBool == true)
        {
            whistleSource.Play();
            whistleBool = false;
        }
    }
}
