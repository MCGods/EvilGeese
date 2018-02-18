using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class Collision : MonoBehaviour {
	public String name1;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == name1)
		{
			Debug.Log ("Here");
			SceneManager.LoadScene("EndGame");
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
