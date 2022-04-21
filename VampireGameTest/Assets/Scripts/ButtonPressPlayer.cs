using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressPlayer : MonoBehaviour
{
    public GameObject platformOn;
    public GameObject platformOff;
    public AudioSource hitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Player")
        {
            platformOn.SetActive(true);
            platformOff.SetActive(false);
            hitButton.Play();
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Player")
    //    {
    //        removeLight.SetActive(true);
    //    }
    //}
}
