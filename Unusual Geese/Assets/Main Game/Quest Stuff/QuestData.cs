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
		TalkBarkeep,
	}
	public enum Stage2QuestTypes{
		GoosyKongScore2,
		BuyGrenade,
		GetWalter
	}
	public enum Stage3QuestTypes{
		GoosyKongScore3,
		LookThroughMicroscope,
		TalkToSomebodyUnconscious
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
		case Stage1QuestTypes.TalkBarkeep:
			if (state.getGameVar ("GlassHouseDialog") == "None") {
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
		case Stage2QuestTypes.GetWalter:
			if (state.getGameVar ("WalterDialogVar") == "None") {
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
		case Stage3QuestTypes.LookThroughMicroscope:
			if (state.getGameVar ("MicroScopeDialog") == "None") {
				return true;
			}
			break;
		case Stage3QuestTypes.TalkToSomebodyUnconscious:
			if (state.getGameVar ("HasSpokenToUnconsciousPerson") == "True") {
				return true;
			}
			break;
		default:
			return false;
		}

		return false;
	}

	public static string stage1Text(Stage1QuestTypes quest){
		switch (quest) {
		case Stage1QuestTypes.FightDoors:
			return "Fight the Nisa Doors";
		case Stage1QuestTypes.GoosyKongScore1:
			return "Score at least 1 on the Goosy Kong machine at the Glasshouse";
		case Stage1QuestTypes.TalkBarkeep:
			return "Talk to the Barkeep at the Glasshouse";
		default:
			return "error";
		}

	}

	public static string stage2Text(Stage2QuestTypes quest){
		switch (quest) {
		case Stage2QuestTypes.BuyGrenade:
			return "Buy a Grenade";
		case Stage2QuestTypes.GoosyKongScore2:
			return "Score at least 2 on the Goosy Kong machine at the Glasshouse";
		case Stage2QuestTypes.GetWalter:
			return "Get Walter the Wizard to join you on your quest";
		default:
			return "error";
		}

	}

	public static string stage3Text(Stage3QuestTypes quest){
		switch (quest) {
		case Stage3QuestTypes.GoosyKongScore3:
			return "Score at least 3 on the Goosy Kong machine at the Glasshouse";
		case Stage3QuestTypes.LookThroughMicroscope:
			return "Look through a microscope";
		case Stage3QuestTypes.TalkToSomebodyUnconscious:
			return "Speak to an unconscious person";
		default:
			return "error";
		}

	}
}
