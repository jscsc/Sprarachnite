using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// Author: Jacob Stone 1/16/17
// Script to regulate the main rules of the game
public class GameManager : MonoBehaviour {

	// Static instance of GameManager, which allows it to be accessed by any other script
	public static GameManager instance = null;

	// Boolean to tell if the game is over
	public static bool gameOver;

	// The amount of lives the player has
	public int amountOfLives;

	// The number of points the player earns when eating a Bug
	public int scoreIncrease = 1;

	// The amount of health to give a Spider when they eat a Bug
	public int healthIncrease = 5;

	// The amount of time in seconds that it takes for the game over menu
	// to display to the player when the game is over
	public float gameOverMenuDelay;

	// Default vertical postion of the Spiders in the game
	public float defaultSpiderHeight;

	// Constant for the Menu Scene index
	private const int MAIN_MENU = 1;

	// Constant for the Gameplay Scene index
	private const int GAME_PLAY_LEVEL = 2;

	// Awake is always called before any Start functions
	void Awake() {
		
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this GameManger
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this GameManger. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a GameManager
			Destroy(gameObject);

		// Call the InitializeGame() function to initialize the main game variables
		initializeGame();
	}

	void Start() {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	// Update is called once every frame
	void Update() {
		if (gameOver) {
			SoundManager.instance.stopPlayingMusic();
			StartCoroutine(InitiateGameOver());
		}
	}

	// Starts the game over processes for the current game
	IEnumerator InitiateGameOver () {
		yield return new WaitForSeconds(gameOverMenuDelay);
		GameOverDisplayer.instance.displayGameOverScreen();
	}

	// Initializes the gameplay
	void initializeGame() {
		gameOver = false;
		LivesManager.lives = amountOfLives;
	}

	// Handles what should happen when a Spider eats a Good Bug
	public void handleGoodBugInteraction(GameObject spider, GameObject bug) {
		// Get the categories of the Spider and Bug that interacted
		Category spiderCategory = spider.GetComponent<SpiderController>().spiderCategory;
		Category bugCategory = bug.GetComponent<BugController>().bugCategory;

		// If the Spider and Bug are in the same category:
		if (spiderCategory == bugCategory) {
			// Increase the player's score
			SoundManager.instance.playSpiderEatSound();
			ScoreManager.score += scoreIncrease;

			// Destory the Bug that was hit
			Destroy(bug);
		} else { 
			// otherwise end the game, the Spider ate the wrong Bug
			SoundManager.instance.playGameOverSound();
			GameOverDisplayer.instance.setGameOverMessageText("You ate the wrong bug");
			gameOver = true;
		}
	}

	public void handleBadBugInteraction() {
		// End the game, the Spider ate the wrong Bug
		SoundManager.instance.playGameOverSound();
		GameOverDisplayer.instance.setGameOverMessageText("You ate a spiked bug");
		gameOver = true;
	}

	// Restarts the games, used by a UI Button
	public void restartGame () {
		SceneManager.LoadScene(GAME_PLAY_LEVEL);
	}

	// Returns to the main menu, used by a UI Button
	public void returnToMainMenu () {
		SceneManager.LoadScene(MAIN_MENU);
	}

}
