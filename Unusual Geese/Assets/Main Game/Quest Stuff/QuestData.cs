using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [NEW FOR ASSESSMENT 4]
/// Quest data.
/// </summary>
public static class QuestData {

	public enum Stage1QuestTypes{
		GoosyKongScore1,
		FightDoors,
		
	}
	public enum Stage2QuestTypes{
		GoosyKongScore2,
		BuyGrenade
	}
	public enum Stage3QuestTypes{
		GoosyKongScore3
	}

	public static bool stage1Complete(Stage1QuestTypes quest){
		GameStateManager state = GameStateManager.getGameStateManager ();
		switch (quest) {
		case Stage1QuestTypes.GoosyKongScore1:
			int highScore = int.Parse (state.getGameVar ("GoosyKongHighScore"));
			if (highScore >= 1) {
				return true;
			}
			break;
		case Stage1QuestTypes.FightDoors:
			if (state.getGameVar ("Closed") == "false") {
				return true;
			}
			break;
		default:
			return false;
		}

		return false;
	}

	public static bool stage2Complete(Stage2QuestTypes quest){
		GameStateManager state = GameStateManager.getGameStateManager ();
		switch (quest) {
		case Stage2QuestTypes.GoosyKongScore2:
			int highScore = int.Parse (state.getGameVar ("GoosyKongHighScore"));
			if (highScore >= 2) {
				return true;
			}
			break;
		case Stage2QuestTypes.BuyGrenade:
			if (state.getGameVar ("hasBoughtGrenade") == "True") {
				return true;
			}
			break;
		default:
			return false;
		}

		return false;
	}

	public static bool stage3Complete(Stage3QuestTypes quest){
		GameStateManager state = GameStateManager.getGameStateManager ();
		switch (quest) {
		case Stage3QuestTypes.GoosyKongScore3:
			int highScore = int.Parse (state.getGameVar ("GoosyKongHighScore"));
			if (highScore >= 3) {
				return true;
			}
			break;
		default:
			return false;
		}

		return false;
	}

}
