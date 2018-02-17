using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bar : MonoBehaviour {

	public GameObject barrel;
	Vector3 whereToSpawn;
	public float spawnRate;
	float nextSpawn=1f;




	void Update () {
		if (Time.time > nextSpawn) {
			nextSpawn = Time.time + spawnRate;
			whereToSpawn = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
			Instantiate (Resources.Load("Barrel2", typeof(GameObject)) as GameObject, whereToSpawn, Quaternion.identity);
		}






	}


}
