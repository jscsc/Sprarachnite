using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to handle the player keyboard interactions with the game over screen
public class GameOverKeyboardHandler : MonoBehaviour {

	// Reference to the restart button
	public Button restartButton;

	// Reference to the main menu button
	public Button mainMenuButton;

	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Return)) && restartButton.IsActive())
			restartButton.onClick.Invoke();
		else if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Escape)) && mainMenuButton.IsActive())
			mainMenuButton.onClick.Invoke();
	}
}
