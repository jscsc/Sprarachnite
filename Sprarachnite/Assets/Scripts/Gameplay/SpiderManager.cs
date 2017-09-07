using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manager the variables for Spiders in the game
public class SpiderManager : MonoBehaviour {
	
	// Static instance of SpiderManager, which allows it to be accessed by any other script
	public static SpiderManager instance = null;
	
	// The speed at which spiders move
	public float spiderSpeed;

	// The speed of spider animations
	public float spiderAnimationSpeed;

	// Awake is always called before any Start functions
	void Awake() {
		
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this SpiderManager
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this SpiderManager. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a SpiderManager
			Destroy(gameObject);
	}

}
