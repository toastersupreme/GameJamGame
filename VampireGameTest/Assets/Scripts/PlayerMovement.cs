using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//movement
	public float maxSpeed;
	public bool facingRight = true;
	public bool canMove = true;

	Rigidbody2D myRB;
	Animator myAnim;
	SpriteRenderer myRenderer;
	public Collider2D boxPush;

	//for jumping 
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;


	// Use this for initialization
	void Start()
	{
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		myRenderer = GetComponent<SpriteRenderer>();
	}


	void Update()
	{
		if (canMove && grounded && Input.GetAxis("Jump") > 0)
		{
			myAnim.SetBool("isGrounded", false);
			myRB.velocity = new Vector2(myRB.velocity.x, 0f);
			myRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
			grounded = false;
		}

		//check if grounded
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded", grounded);

		//jumping code
		myAnim.SetFloat("verticalVelocity", myRB.velocity.y);


		//running code
		float move = Input.GetAxis("Horizontal");

		if (canMove)
		{
			if (move > 0 && !facingRight) Flip();
			else if (move < 0 && facingRight) Flip();


			myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
			myAnim.SetFloat("moveVelocity", Mathf.Abs(move));
		}
		else
		{
			myRB.velocity = new Vector2(0, myRB.velocity.y);
			myAnim.SetFloat("moveVelocity", 0);
		}

		
	}



	void Flip()
	{
		facingRight = !facingRight;
		//myRenderer.flipX = !myRenderer.flipX;
		transform.Rotate(new Vector3(0, 180, 0));
	}

	public void toggleCanMoveTrue()
	{
		canMove = true;
	}

	public void toggleCanMoveFalse()
	{
		canMove = false;
	}

	public void increaseSpeed()
	{
		maxSpeed *= 2;
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
			myAnim.SetBool("pushingBox", true);
        }
    }

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Box")
		{
			myAnim.SetBool("pushingBox", false);
		}
	}
}
