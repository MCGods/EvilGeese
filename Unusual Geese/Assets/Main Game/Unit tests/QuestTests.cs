using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestTests {
	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator QuestsProgress() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
		SceneManager.LoadScene ("Main Game/Scenes/RonCookeHub");
		yield return null;

		GameStateManager state = GameStateManager.getGameStateManager ();
		state.state.s1Quest = QuestData.Stage1QuestTypes.GoosyKongScore1;
		state.state.s2Quest = QuestData.Stage2QuestTypes.GoosyKongScore2;
		state.state.s3Quest = QuestData.Stage3QuestTypes.GoosyKongScore3;
		state.state.questState = 0;

		state.setGameVar ("GoosyKongHighScore", "0");
		state.tryQuestProgression ();
		Assert.AreEqual (state.state.questState, 0);
		state.setGameVar ("GoosyKongHighScore", "1");
		state.tryQuestProgression ();
		Assert.AreEqual (state.state.questState, 1);
		state.setGameVar ("GoosyKongHighScore", "2");
		state.tryQuestProgression ();
		Assert.AreEqual (state.state.questState, 2);
		state.setGameVar ("GoosyKongHighScore", "3");
		state.tryQuestProgression ();
		Assert.AreEqual (state.state.questState, 3);

	}
}
