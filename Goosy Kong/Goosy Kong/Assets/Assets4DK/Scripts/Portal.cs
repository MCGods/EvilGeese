using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Portal : MonoBehaviour {

	public int currentScene;
	private int nextScene;
	public Text moneyText;
	private int x;


	// Use this for initialization
	void Start () {
		DisplayMoney ();
	}





	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Goose") {
			if(currentScene == 0){
				x = PlayerPrefs.GetInt ("Reward");
				x = x + 5;
				PlayerPrefs.SetInt ("Reward", x);
				nextScene = currentScene + 1;

				SceneManager.LoadScene ("Main " + nextScene);
			

			
			}
			if (currentScene == 1) {
				x = PlayerPrefs.GetInt ("Reward");
				x = x + 10;
				PlayerPrefs.SetInt ("Reward", x);
				nextScene = currentScene + 1;
				SceneManager.LoadScene ("Main " + nextScene);

			}

		}
	}
	void DisplayMoney(){
		moneyText.text = "Money: " + PlayerPrefs.GetInt ("Reward").ToString ();

	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
