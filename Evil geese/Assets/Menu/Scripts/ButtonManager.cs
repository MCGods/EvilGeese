using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// [CHANGES] - Now used for the canvas for loading a game from the main menu as well
/// [EXTENSIONS] - Added functions for load button and loading saves
/// 			 - Added sound effect on button press
/// </summary>
public class ButtonManager : MonoBehaviour {

	//starts a new game, called when the new game button on the menu is pressed
	public void NewGameBtn(string newGameScene){
		SoundManager.instance.playSFX ("interact");
		GameStateManager state = GameObject.FindGameObjectWithTag ("GameStateManager").GetComponent<GameStateManager> ();
		state.state = new GameState ();
		state.availibleCharacters.Add (CombatCharacterFactory.CombatCharacterPresets.BobbyBard);
		state.currentTeam.Add (CombatCharacterFactory.CombatCharacterPresets.BobbyBard);
		state.availibleCharacters.Add (CombatCharacterFactory.CombatCharacterPresets.CharlieCleric);
		state.currentTeam.Add (CombatCharacterFactory.CombatCharacterPresets.CharlieCleric);
		state.availibleCharacters.Add (CombatCharacterFactory.CombatCharacterPresets.MabelMage);
		state.currentTeam.Add (CombatCharacterFactory.CombatCharacterPresets.MabelMage);
		SceneManager.LoadScene (newGameScene);
	}

	/// <summary>
	/// [EXTENSION] - Added function to handle load button press
	/// </summary>
	public void LoadGamePanel() {
		Instantiate (Resources.Load ("LoadPanel"), GameObject.Find ("MainMenu").transform);
	}

	/// <summary>
	/// [EXTENSION] - Added function to handle cancel press in loadCanvas
	/// </summary>
	public void HideLoadPanel() {
		Destroy (gameObject);
	}

	/// <summary>
	/// [EXTENSION] - Added function to load a save file, used by loadCanvas and demoSave button in main menu
	/// </summary>
	/// <param name="saveName">Save name.</param>
	public void LoadGame(string saveName) {
		SoundManager.instance.playSFX ("interact");
		GameStateManager state = GameObject.FindGameObjectWithTag ("GameStateManager").GetComponent<GameStateManager> ();
		state.state = GameSave.loadState (saveName);
		Instantiate (Resources.Load ("TimerObject"));
		SceneManager.LoadScene (state.state.sceneName);
	}

	// quits the game, called when the exit game button is pressed
	public void ExitGameBtn(){
		Application.Quit ();
	}
}
