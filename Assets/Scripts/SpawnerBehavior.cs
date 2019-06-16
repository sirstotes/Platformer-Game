using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour {
	public List<GameObject> spawnableObjects;
	private List<GameObject> spawnedObjects = new List<GameObject>();
	public Vector2 minPosition;
	public Vector2 maxPosition;
	public Vector2 startVelocity;
	public bool isParent = true;
	public bool alwaysActive = false;
	public int max = 0;
	public int spawnAmount = 0;
	public float spawnTimeMin = 0;
	public float spawnTimeMax = 0;
	private float currentSpawnTime = 0;
	private float counter = 0;
	void Start () {
		
	}
	
	void Update () {
		if(alwaysActive && (spawnedObjects.Count < max || max == 0)) {
			counter += Time.deltaTime;
			if(counter >= currentSpawnTime) {
				counter = 0;
				currentSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
				Spawn(spawnAmount);
			}
		}
		for(int i = spawnedObjects.Count-1; i > 0; i--) {
			if(spawnedObjects[i] == null) {
				spawnedObjects.RemoveAt(i);
			}
		}
	}

	public void Spawn(int amount) {
		for (int i = 0; i < amount; i ++) {
			GameObject obj = spawnableObjects[Random.Range(0, spawnableObjects.Count-1)];
			Vector3 pos = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), 0);
			if(isParent) {
				spawnedObjects.Add(Instantiate(obj, transform.position+pos, Quaternion.identity, transform));
			} else {
				spawnedObjects.Add(Instantiate(obj, transform.position+pos, Quaternion.identity));
			}
			spawnedObjects[spawnedObjects.Count-1].GetComponent<Rigidbody2D>().velocity = startVelocity;
		}
	}
}
