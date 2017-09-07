using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to destory any GameObject that leaves the boundary
public class DestroyByBoundary : MonoBehaviour {

	// Function that is called when an object leaves the Trigger
	// on this game object
	void OnTriggerExit2D(Collider2D other) {
		// If the gameobejct we hit was a good bad:
		if (other.gameObject.tag == "GoodBug") {
			// Decrease the player lives
			LivesManager.lives--;

			// If this wasnt the last life, play the bug miss sound
			if (LivesManager.lives > 0)
				SoundManager.instance.playBugMissSound();	
		}

		// Destroy the GameObject that left this trigger
        Destroy(other.gameObject);
    }

}
