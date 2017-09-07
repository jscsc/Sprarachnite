using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Author: Jacob Stone 1/16/17
// Script used to load the first scene of the game (the main menu).
// This helps with preloading the main scenes of the game
public class GameLoader : MonoBehaviour {
	
	// Constant for the Menu Scene index
	private const int MAIN_MENU = 1;

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene(MAIN_MENU);
	}

}
