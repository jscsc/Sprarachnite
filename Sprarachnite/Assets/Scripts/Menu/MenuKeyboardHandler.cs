using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Author: Jacob Stone 1/16/17
// Script to handle the keyboard inputs from the player on the menu
public class MenuKeyboardHandler : MonoBehaviour {

	// Reference to the start button
	public Button startButton;

	// Reference to the rules button
	public Button rulesButton;

	// Reference to the credits button
	public Button creditsButton;

	// Reference to the exit button
	public Button exitButton;

	// Reference to the back button
	public Button backButton;
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Return)) && startButton.IsActive())
			startButton.onClick.Invoke();
		 else if((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Escape)) && exitButton.IsActive())
			exitButton.onClick.Invoke();
		else if(Input.GetKeyDown(KeyCode.LeftArrow) && creditsButton.IsActive())
			creditsButton.onClick.Invoke();
		else if(Input.GetKeyDown(KeyCode.RightArrow) && rulesButton.IsActive())
			rulesButton.onClick.Invoke();
		else if( (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Escape)) && backButton.IsActive())
			backButton.onClick.Invoke();
	}
}
