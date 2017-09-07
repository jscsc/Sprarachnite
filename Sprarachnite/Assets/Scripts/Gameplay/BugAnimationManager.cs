using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the speed of a Bug's animation
public class BugAnimationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Animator>().speed = BugManager.instance.bugAnimationSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		// If the game is over, stop the Bug's animation
		if (GameManager.gameOver)
			this.gameObject.GetComponent<Animator>().speed = 0.0f;
		
	}
}
