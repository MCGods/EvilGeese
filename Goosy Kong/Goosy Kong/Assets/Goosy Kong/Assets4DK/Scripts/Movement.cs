using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpeed;
	public float jumpHeight;
	public GameObject goose;
	public bool facingRight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	bool grounded = true;



	// Use this for initialization
	void Start () {
		facingRight = true;
		

		
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			Jump ();

		}
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			if ((facingRight) == false) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				goose.transform.localScale = theScale;
				facingRight = true;
			}

				

		}
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			if ((facingRight) == true) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				goose.transform.localScale = theScale;
				facingRight = false;
			}
		
		}

	}

	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);

	}
	public void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
} 

