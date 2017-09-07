using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to handle displaying the game over screen
public class GameOverDisplayer : MonoBehaviour {

	// Static instance of GameOverDisplayer, which allows it to be accessed by any other script
	public static GameOverDisplayer instance = null;

	// The score text in the game
	public Text scoreText;

	// The lives text in the game
	public Text livesText;

	// The restart button in the game
	public Button restartButton;

	// The main menu button in the game
	public Button mainMenuButton;

	// The game over text in the game
	public Text gameOverText;

	// The game over message text in the game
	public Text gameOverMessageText;

	// The final score text in the game
	public Text finalScoreText;

	// Awake is always called before any Start functions
	void Awake() {

		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this GameOverDisplayer
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this GameOverDisplayer. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a GameOverDisplayer
			Destroy(gameObject);
	}
	
	// Use this for initialization
	void Start () {
		setGameOverScreen(false);
		setGamePlayHUD(true);
	}

	// Displays the game over screen
	public void displayGameOverScreen () {
		disableGameObjectsWithTag("Spider");
		disableGameObjectsWithTag("GoodBug");
		disableGameObjectsWithTag("BadBug");
		setGamePlayHUD(false);
		setGameOverScreen(true);
		setFinalScoreText();
	}

	// Sets the text of the game over message
	public void setGameOverMessageText (string Text ) {
		gameOverMessageText.text = Text;
	}

	// Sets the final score text to use the current games score
	private void setFinalScoreText () {
		// Handle the special case of only eating one Bug
		if (ScoreManager.score == 1)
			finalScoreText.text = "You ate 1 bug";
		else
			finalScoreText.text = "You ate " + ScoreManager.score + " bugs";
	}

	// Disables gameobjects in the current scene with the tag passed in
	private void disableGameObjectsWithTag (string tag) {
		// Get all the game objects in the scene with the tag passed in
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

		// For each gameobject it found with the tag, disable it
		foreach(GameObject gameObject in gameObjects) {
			gameObject.SetActive(false);
		}
	}

	// Sets the gameplay HUD to display or not according to the boolean
	// passed into the fuction
	private void setGamePlayHUD (bool setting) {
		scoreText.gameObject.SetActive(setting);
		livesText.gameObject.SetActive(setting);
	}

	// Sets the game over screen to display or not according to the boolean
	// passed into the fuction
	private void setGameOverScreen (bool setting) {
		restartButton.gameObject.SetActive(setting);
		mainMenuButton.gameObject.SetActive(setting);
		gameOverText.gameObject.SetActive(setting);
		gameOverMessageText.gameObject.SetActive(setting);
		finalScoreText.gameObject.SetActive(setting);
	}

}
