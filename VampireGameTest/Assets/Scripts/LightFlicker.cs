using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public GameObject lightToFlicker;

    float timeLeftOn;
    float timeLeftOff;

    public float maxTimeOn = 7f;
    public float maxTimeOff = 4f;


    public bool isLightOn;

    // Start is called before the first frame update
    void Start()
    {
        timeLeftOff = Random.Range(3, maxTimeOff);
        timeLeftOn = Random.Range(3, maxTimeOn);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
            TurnLightOff();
        } else
        {
            TurnLightOn();
        }
    }


    void TurnLightOff()
    {
        if (timeLeftOn <= 0)
        {
            lightToFlicker.SetActive(false);
            timeLeftOn = Random.Range(3, maxTimeOn);
            isLightOn = false;
        }
        else
        {
            timeLeftOn -= Time.deltaTime;
        }
    }

    void TurnLightOn()
    {
        print(timeLeftOff);
        if (timeLeftOff <= 0)
        {
            
            lightToFlicker.SetActive(true);
            timeLeftOff = Random.Range(3, maxTimeOff);
            isLightOn = true;
        }
        else
        {
            timeLeftOff -= Time.deltaTime;
        }
    }
}
