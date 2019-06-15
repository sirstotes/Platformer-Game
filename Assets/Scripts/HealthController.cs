using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour {
	public float damage = 0;
	private float maxHealth;
	public float health = 0;
	public int regen = 0;
	public float regenTime = 0;
	private float counter = 0;
	public LayerMask whatIsHarmful;
	public UnityEvent doOnDeath;
	public bool changeSprite = false;
	public List<Sprite> sprites;
	void Start() {
		maxHealth = health;
	}
	void Update () {
		if(health <= 0) {
			doOnDeath.Invoke();
		}
		counter += Time.deltaTime;
		if(counter >= regenTime) {
			counter = 0;
			health += regen;
		}
		if(health > maxHealth) {
			health = maxHealth;
		}
		if(changeSprite) {
			for(int i = sprites.Count-1; i >= 0; i --) {
				//Debug.Log(i+", "+health/maxHealth+", "+(sprites.Count-i)+"/"+sprites.Count+", "+(health/maxHealth <= (sprites.Count-i)/sprites.Count));
				if(health/maxHealth <= ((float)sprites.Count-i)/(float)sprites.Count) {
					gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
					return;
				}
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other) {
		if(whatIsHarmful == (whatIsHarmful | (1 << other.gameObject.layer))) {
			if(other.gameObject.GetComponent<HealthController>() == null) {
				health = 0;
			} else {
				health -= other.gameObject.GetComponent<HealthController>().damage;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(whatIsHarmful == (whatIsHarmful | (1 << other.gameObject.layer))) {
			if(other.gameObject.GetComponent<HealthController>() == null) {
				health = 0;
			} else {
				health -= other.gameObject.GetComponent<HealthController>().damage;
			}
		}
	}
	public void DestroySelf() {
		Destroy(gameObject);
	}
}
