using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class Menu : MonoBehaviour {
	public Canvas quitMenu;
	public Button exitText;



	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas>();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		
	}
	public void ExitPress()
	{
		quitMenu.enabled = true;
		exitText.enabled = false;
	}
	
	public void NoPress()
	{
		quitMenu.enabled = false;
		exitText.enabled = true;
	}

	public void LeaveLevel(){
		SceneManager.LoadScene ("EndGame");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
