using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject prompt;
    public GameObject objectToAffect;
    SpriteRenderer sr;

    SwitchEffectController sec;

    bool isSwitched;
    bool inRange;

    private void OnTriggerStay2D(Collider2D collision)
    {
        inRange = true;
        prompt.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
        prompt.gameObject.SetActive(false);
    }

    private void Awake()
    {
        sec = gameObject.GetComponent<SwitchEffectController>();
        sec.effectedObject = objectToAffect;
    }

    private void Start()
    {
        sr = gameObject.transform.parent.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {
            if (isSwitched)
            {
                SwitchDeactive();
            } else
            {
                SwitchActive();
            }
        }
    }


    void SwitchActive()
    {
        sr.color = Color.yellow;
        isSwitched = true;
        sec.buttonIsDown = isSwitched;
    }

    void SwitchDeactive()
    {
        sr.color = Color.blue;
        isSwitched = false;
        sec.buttonIsDown = isSwitched;
    }

}
