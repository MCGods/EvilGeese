using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
/// <summary>
/// [EXTENSIONS] - Added giveMoney as an action type
/// </summary>
public class DialogAction {
	public enum actionType{
		setGameVar,
		giveMoney,
		startCombat,
		giveItem,
		setCharacterAvailibility
	}
	public actionType ownActionType;
	public string gameVarName = "";
	public string gameVarValue = "";
	public int gameVarNumber = 0;
	public List<CombatCharacterFactory.CombatCharacterPresets> combatEnemies;
	public InventoryItems.itemTypes itemType;
	public int itemAmount;

	public CombatCharacterFactory.CombatCharacterPresets character;
	public bool charAvailible;

	public DialogAction (){
		combatEnemies = new List<CombatCharacterFactory.CombatCharacterPresets> ();
	}

	public void doAction(){
		GameStateManager state = GameObject.FindGameObjectWithTag ("GameStateManager").GetComponent<GameStateManager> ();
		switch (ownActionType) {
		case actionType.setGameVar:
			state.setGameVar (gameVarName, gameVarValue);
			break;
		// [EXTENSION] - Call GameStateManager.giveMoney to give or take the specified money
		case actionType.giveMoney:
			state.giveMoney (gameVarNumber);
			break;
		case actionType.startCombat:
			CombatManager.startCombat (combatEnemies);
			break;
		case actionType.giveItem:
			state.changeItem (itemType, itemAmount);
			break;
		case actionType.setCharacterAvailibility:
			if (charAvailible) {
				if (!state.availibleCharacters.Contains (character)) {
					state.availibleCharacters.Add (character);
				}
			} else {
				if (state.availibleCharacters.Contains (character)) {
					state.availibleCharacters.Remove (character);
				}
				if (state.currentTeam.Contains (character)) {
					state.currentTeam.Remove (character);
				}
			}
			break;
		}
	}
}
