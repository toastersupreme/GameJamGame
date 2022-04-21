using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEffectController : MonoBehaviour
{
    [HideInInspector]
    public bool buttonIsDown = false;

    [Header("EffectType: Active Switcher")]
    public bool isActiveSwitcher;
    public bool startActive;
    bool activeDefault;
    public bool turnOff;

    [HideInInspector]
    public GameObject effectedObject;

    private void Start()
    {
        activeDefault = startActive;
        SwitcherDefault();
    }

    private void Update()
    {

            if (buttonIsDown)
            {
                Switcher();
            }
            else
            {
                SwitcherDefault();
            }
    }

    void SwitcherDefault()
    {
        if (isActiveSwitcher)
        {
            effectedObject.gameObject.SetActive(activeDefault);
        }

    }

    void Switcher()
    {
        if (isActiveSwitcher && startActive)
        {
            effectedObject.gameObject.SetActive(false);
        }
        else if (isActiveSwitcher)
        {
            effectedObject.gameObject.SetActive(true);
        }
    }

}
