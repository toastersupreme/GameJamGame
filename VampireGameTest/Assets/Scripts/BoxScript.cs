using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject box;
    public GameObject boxSpawn;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "KillArea2")
        {
            KillBox();
        }
    }

    private void KillBox()
    {
        //Destroy(gameObject);
        //Instantiate(box, boxSpawn.transform);
        this.transform.position = boxSpawn.transform.position;
        rb.velocity = new Vector2(0, 0);
    }
}
