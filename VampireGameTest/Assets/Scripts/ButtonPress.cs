using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject removeLight;
    public GameObject moveLight;

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
            removeLight.SetActive(false);
            moveLight.transform.position = new Vector3(-1.3f, 9.59f, 0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
           removeLight.SetActive(true);
            moveLight.transform.position = new Vector3(-1.3f, 9.59f, 0);
        }
    }
}
