using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour {
	private Rigidbody2D rb2D;
	public MotionController mt;
	public HealthController hc;
	public SpawnerBehavior spawn;
	public Text healthDisplay;
	public Controls c;
	public float jumpPeak = 0f;
	public float jumpTime = 0f;
	public float jumpSpeed = 0f;
	private float jumpVelocity = 0f;
	public float walkSpeed = 0f;
	public float timeHeld = 0f;
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
		if (c.GetVertical() > 0 && (mt.isGrounded || timeHeld > 0) && timeHeld < jumpTime) {
			timeHeld += Time.deltaTime;
			jumpVelocity = (jumpSpeed*Mathf.Pow(timeHeld-jumpTime, 2))+jumpPeak;
			rb2D.velocity = new Vector2(rb2D.velocity.x, jumpVelocity);
			//mt.MoveUp(jumpVelocity);
		} else {
			timeHeld = 0;
		}
			
		spawn.enabled = c.GetShoot();
		spawn.startVelocity = c.GetShootDirection()*50;
	}
	void Update () {
		healthDisplay.text = "Health: "+hc.health;

	}
}
