using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehavior : MonoBehaviour {
	public GameObject player;
	public float sightDistance = 0;
	public bool seesPlayer = false;
	public UnityEvent onPlayerSeen;
	public UnityEvent onPlayerNotSeen;
	public MotionController motionController;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position, player.transform.position) <= sightDistance) {
			seesPlayer = true;
		} else if(Vector2.Distance(transform.position, player.transform.position) >= sightDistance*2) {
			seesPlayer = false;
		}
		if(seesPlayer) {
			onPlayerSeen.Invoke();
		} else {
			onPlayerNotSeen.Invoke();
		}
	}

	public void MoveToPlayerX(string speed) {
		if(transform.position.x < player.transform.position.x) {
			motionController.MoveRight(float.Parse(speed));
		} else {
			motionController.MoveLeft(float.Parse(speed));
		}
	}
	public void MoveToPlayerY(string speed) {
		if(transform.position.y < player.transform.position.y) {
			motionController.MoveUp(float.Parse(speed));
		} else {
			motionController.MoveDown(float.Parse(speed));
		}
	}
	public void StayStill() {
		motionController.Friction(5, 1);
	}
}
