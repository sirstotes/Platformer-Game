using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {

	private Rigidbody2D rb2D;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGrounded;
	public float maxSpeedX;
	public float maxSpeedY;
	// Use this for initialization
	void Start () {
		rb2D = transform.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate() {
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround) && rb2D.velocity.y <= 0;
		if(rb2D.velocity.x > maxSpeedX) {
			rb2D.velocity = new Vector2(maxSpeedX, rb2D.velocity.y);
		} else if(rb2D.velocity.x < -maxSpeedX) {
			rb2D.velocity = new Vector2(-maxSpeedX, rb2D.velocity.y);
		}
		if(rb2D.velocity.y > maxSpeedY) {
			rb2D.velocity = new Vector2(rb2D.velocity.x, maxSpeedY);
		} else if(rb2D.velocity.y < -maxSpeedY) {
			rb2D.velocity = new Vector2(rb2D.velocity.x, -maxSpeedY);
		}
	}
	public void MoveRight (float speed) {
		rb2D.AddForce(new Vector2 (speed, 0));
	}
	public void MoveLeft (float speed) {
		rb2D.AddForce(new Vector2 (-speed, 0));
	}
	public void MoveUp (float speed) {
		rb2D.AddForce(new Vector2 (0, speed));
	}
	public void MoveDown (float speed) {
		rb2D.AddForce(new Vector2 (0, -speed));
	}
	public void Friction (float amountX, float amountY) {
		rb2D.velocity = new Vector2(rb2D.velocity.x*(1f/amountX), rb2D.velocity.y*(1f/amountY));
	}
}
