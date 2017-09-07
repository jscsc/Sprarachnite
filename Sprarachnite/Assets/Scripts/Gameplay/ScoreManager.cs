using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the score of current the game.
// Class modeled from the Unity Learn 2D Roguelike Tutorial.
public class ScoreManager : MonoBehaviour {
	
	// The player's score
	public static int score;

	// Refernce to the Text component for score
	Text text;

	// Awake is always called before any Start functions
	void Awake () {
		// Set up the reference
		text = GetComponent<Text>();

		// Reset the score
		score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Set the text to the score
		text.text = score.ToString ();
		if (score == int.MaxValue && !GameManager.gameOver) {
			GameManager.gameOver = true;
			GameOverDisplayer.instance.setGameOverMessageText ("l'Hôpital was a good man");
			SoundManager.instance.playGameOverSound();
		}
	}

}
