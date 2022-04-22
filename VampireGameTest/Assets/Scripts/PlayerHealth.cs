using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image fillImage;
    public GameObject spawn;
    public float exposureNum;
    public AudioSource exposedLight;

    public float maxExposure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillImage.fillAmount = exposureNum / maxExposure;
        if (exposureNum > maxExposure)
        {
            KillPlayer();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            exposureNum++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KillArea")
        {
            KillPlayer();
        }
        if(collision.gameObject.tag == "Light")
        {
            exposedLight.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Light")
        {
            exposedLight.Pause();
        }
    }

    private void KillPlayer()
    {
        //Destroy(gameObject);
        this.transform.position = spawn.transform.position;
    }
}
