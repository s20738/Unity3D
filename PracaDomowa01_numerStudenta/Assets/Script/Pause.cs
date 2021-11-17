using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPause;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        isPause = true;
        text.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
                Pas();
            }
        }


    }

    private void Resume()
    {
        isPause = false;
        Time.timeScale = 1f;
        text.SetActive(false);

    }

    private void Pas()
    {
        isPause = true;
        Time.timeScale = 0f;
        text.SetActive(true);
    }
}

