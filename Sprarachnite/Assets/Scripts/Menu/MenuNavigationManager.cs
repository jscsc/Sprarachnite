using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

// Author: Jacob Stone 1/16/17
// Script used to naviagte the main menu
public class MenuNavigationManager : MonoBehaviour {

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

	// Reference to the statement text
	public Text statementText;

	// Reference to the author text
	public Text authorText;

	// Reference to the rules text
	public Text rulesText;

	// Reference to the title text
	public Text titleText;

	// Reference to the creator text
	public Text creatorText;

	// Reference to the art text
	public Text artText;

	// Reference to the code text
	public Text codeText;

	// Reference to the sound effects text
	public Text soundEffectsText;

	// Reference to the music text
	public Text musicText;

	// Constant for the Gameplay scene index
	private const int GAME_PLAY_LEVEL = 2;
	
	// Use this for initialization
	void Start () {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		goToMainMenu();
	}

	//Removes the UI elements that make up the menu screen
	private void removeMenuUI () {
		startButton.gameObject.SetActive(false);
		rulesButton.gameObject.SetActive(false);
		creditsButton.gameObject.SetActive(false);
		exitButton.gameObject.SetActive(false);
		backButton.gameObject.SetActive(false);
		statementText.gameObject.SetActive(false);
		authorText.gameObject.SetActive(false);
		rulesText.gameObject.SetActive(false);
		titleText.gameObject.SetActive(false);
		creatorText.gameObject.SetActive(false);
		artText.gameObject.SetActive(false);
		codeText.gameObject.SetActive(false);
		soundEffectsText.gameObject.SetActive(false);
		musicText.gameObject.SetActive(false);
		MenuSpiderPicker.instance.removeSpider();
		MenuWebPicker.instance.removeWeb();
	}


	// Displays the credits screen
	public void goToCredits () {
		removeMenuUI();
		backButton.gameObject.SetActive(true);
		titleText.gameObject.SetActive(true);
		creatorText.gameObject.SetActive(true);
		artText.gameObject.SetActive(true);
		codeText.gameObject.SetActive(true);
		soundEffectsText.gameObject.SetActive(true);
		musicText.gameObject.SetActive(true);
		MenuWebPicker.instance.pickWeb(true);
	}

	// Displays the rules screen
	public void goToRules () {
		removeMenuUI();
		backButton.gameObject.SetActive(true);
		rulesText.gameObject.SetActive(true);
		MenuWebPicker.instance.pickWeb(false);

	}

	// Displays the menu screen
	public void goToMainMenu () {
		removeMenuUI();
		startButton.gameObject.SetActive(true);
		rulesButton.gameObject.SetActive(true);
		creditsButton.gameObject.SetActive(true);
		exitButton.gameObject.SetActive(true);
		statementText.gameObject.SetActive(true);
		authorText.gameObject.SetActive(true);
		MenuSpiderPicker.instance.pickSpider();
		MenuQuotePicker.instance.pickQuote();
	}

	// Changes scenes to the gameplay scene
	public void goToGamePlay () {
		SceneManager.LoadScene(GAME_PLAY_LEVEL);
	}

	// Exits the game in a standalone build
	public void exitGame () {
		Application.Quit();
	}

}
