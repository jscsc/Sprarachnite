using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the lives of the player in the current game
public class LivesManager : MonoBehaviour {

	// The player's lives
	public static int lives;

	// Refernce to the Text component for lives
	Text text;

	// Awake is always called before any Start functions
	void Awake() {
		// Set up the reference
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		// If the player lives is less than or equal to zero:
		if (lives <= 0) {
			// Set the text to zero and end the game
			if (!GameManager.gameOver) {
				text.text = "0";
				GameOverDisplayer.instance.setGameOverMessageText("Too many bugs escaped");
				SoundManager.instance.playGameOverSound();
				GameManager.gameOver = true;
			}

		} else {
			// Otherwise update the lives like normal
			text.text = lives.ToString();
		}
	}

}
