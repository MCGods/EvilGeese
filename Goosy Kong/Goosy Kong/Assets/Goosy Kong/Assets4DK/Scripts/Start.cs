using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour {

	public string leaveGame;

	public void StartGame(){
		SceneManager.LoadScene("Main");
		PlayerPrefs.SetInt ("Reward", 0);

	}
	public void LeaveGame(){
		GameState state = GameStateManager.getGameStateManager ().state;
		state.playerX = 6;
		state.playerY = -1;
		SoundManager.instance.playBGM ("main");
		SceneManager.LoadScene ("Main Game/Scenes/Glasshouse");

	}


}
