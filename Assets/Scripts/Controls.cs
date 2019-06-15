using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public float GetHorizontal () {
		return Input.GetAxisRaw("Horizontal");
	}
	public float GetVertical () {
		return Input.GetAxisRaw("Vertical");
	}
}
