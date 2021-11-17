using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSript : MonoBehaviour
{
    public GameObject hearth1, hearth2, hearth3;
   public GameObject emtyHearth1, emtyHearth2, emtyHearth3;
    public static int health;
    void Start()
    {
        hearth1.SetActive(true);
        emtyHearth1.SetActive(true);
        hearth2.SetActive(true);
        emtyHearth2.SetActive(true);
        hearth3.SetActive(true);
        emtyHearth3.SetActive(true);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        switch(health)
            {
            case 3:
                hearth1.SetActive(true);
                hearth2.SetActive(true);
                hearth3.SetActive(true);
                break;
            case 2:
                hearth1.SetActive(false);
                hearth2.SetActive(true);
                hearth3.SetActive(true);
                break;
            case 1:
                hearth1.SetActive(false);
                hearth2.SetActive(false);
                hearth3.SetActive(true);
              
                break;
            case 0:
                hearth1.SetActive(false);
                hearth2.SetActive(false);
                hearth3.SetActive(false);
                break;
        }
    }
}
