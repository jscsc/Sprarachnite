using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script that controls specific bug actions in the game
public class BugController : MonoBehaviour {
	
	// The type of spider this bug is for
	public Category bugCategory;
	
	// Update is called once per frame
	void Update () {
		// If the game is not over, move the Bug to the right
		if (!GameManager.gameOver)
			transform.Translate(Vector3.right * BugManager.instance.bugSpeed * Time.deltaTime);
	}

}
