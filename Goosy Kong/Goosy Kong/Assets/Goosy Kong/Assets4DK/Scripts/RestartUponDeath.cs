using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartUponDeath : MonoBehaviour {
	public GameObject goose;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (goose.transform.position.y < -7.8) {
			SceneManager.LoadScene ("EndGame");

		}
		
		
	}
}
