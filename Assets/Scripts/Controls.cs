using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	void Start () {
	}
	public float GetHorizontal () {
		return Input.GetAxisRaw("Horizontal");
	}
	public float GetVertical () {
		return Input.GetAxisRaw("Vertical");
	}
	public bool GetShoot () {
		return Input.GetMouseButton(1);
	}
	public Vector2 GetShootDirection () {
		Vector2 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		direction.Normalize();
		return direction;
	}
}
