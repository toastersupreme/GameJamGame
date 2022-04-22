using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject removeLight;
    public GameObject moveLight;

    public GameObject removeObject;

    public AudioSource Switch;

    public bool onlyIfPressed;

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
        if (collision.gameObject.tag == "Box")
        {
            Switch.Play();
            removeLight.SetActive(false);
            removeObject.SetActive(false);
            moveLight.transform.position = new Vector3(-1.3f, 9.59f, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            if (onlyIfPressed)
            {
                removeLight.SetActive(true);
                moveLight.transform.position = new Vector3(-1.3f, 9.59f, 0);
            }
        }
    }
}
