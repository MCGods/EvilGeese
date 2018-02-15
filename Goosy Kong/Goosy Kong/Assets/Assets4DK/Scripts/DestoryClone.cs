using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DestoryClone : MonoBehaviour {
	public GameObject barrel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (barrel.transform.position.y < -7.7) {
			Debug.Log ("hello");

			Destroy (gameObject);
		}
	}
}
