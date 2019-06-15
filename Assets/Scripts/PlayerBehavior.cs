using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {
	private Rigidbody2D rb2D;
	public MotionController mt;
	public HealthController hc;
	public Text healthDisplay;
	public Controls c;
	public float jumpSpeed = 0f;
	public float walkSpeed = 0f;
	void Start () {
		rb2D = transform.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate() {
		if (c.GetHorizontal() > 0) {
			if(mt.isGrounded) {
				mt.MoveRight(walkSpeed);
			} else {
				mt.MoveRight(walkSpeed*0.8f);
			}
		} else if (c.GetHorizontal() < 0) {
			if(mt.isGrounded) {
				mt.MoveLeft(walkSpeed);
			} else {
				mt.MoveLeft(walkSpeed*0.8f);
			}
		} else {
			if(mt.isGrounded) {
				mt.Friction(2, 1);
			} else {
				mt.Friction(3, 1);
			}
		}
		if (c.GetVertical() > 0 && (/*mt.isGrounded || */rb2D.velocity.y >= 0)) {
			if(rb2D.velocity.y == 0) {
				mt.MoveUp(jumpSpeed);
			} else {
				mt.MoveUp(jumpSpeed/rb2D.velocity.y/2);
			}
		}
	}
	void Update () {
		healthDisplay.text = "Health: "+hc.health;
	}
}
