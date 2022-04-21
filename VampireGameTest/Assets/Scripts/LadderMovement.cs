using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder = false;
    private bool isClimbing = false;

    private float gScaleFixed;

    [SerializeField] 
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject objectToPass;

    private void Awake()
    {
        gScaleFixed = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
            objectToPass.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectToPass.GetComponent<BoxCollider2D>().enabled = true;
            rb.gravityScale = gScaleFixed;
        }

    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        } else
        {
            objectToPass.GetComponent<BoxCollider2D>().enabled = true;
            rb.gravityScale = gScaleFixed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
