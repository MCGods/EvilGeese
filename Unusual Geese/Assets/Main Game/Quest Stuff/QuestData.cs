using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [NEW FOR ASSESSMENT 4]
/// Quest data.
/// </summary>
public static class QuestData {

	public enum Stage1QuestTypes{
		
	}
	public enum Stage2QuestTypes{

	}
	public enum Stage3QuestTypes{

	}

	public static bool stage1Complete(Stage1QuestTypes quest){
		switch (quest) {

		default:
			return false;
		}
	}

	public static bool stage2Complete(Stage2QuestTypes quest){
		switch (quest) {

		default:
			return false;
		}
	}

	public static bool stage3Complete(Stage3QuestTypes quest){
		switch (quest) {

		default:
			return false;
		}
	}

}
