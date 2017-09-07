using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the way that Bugs spawn in the game
public class BugManager : MonoBehaviour {

	// Static instance of GameManger, which allows it to be accessed by any other script
	public static BugManager instance = null;
	
	// Speed for all bugs to move at in the game
	public float bugSpeed = 2.0f;

	// The speed of Bug animations
	public float bugAnimationSpeed;

	// The chance at which a bad bug a spawn
	public int badBugChance = 5;

	// The types of good bugs that can be spawned
	public GameObject[] goodBugs;

	// The types of bad bugs that can be spawned
	public GameObject[] badBugs;

	// Values to spawn bugs at
	public Vector3 spawnValues;

	// Time to wait until bugs start spawning
	public float startWait;

	// Time to wait between bug spawns
	public float spawnWait;

	// Awake is always called before any Start functions
	void Awake() {
		
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this BugManager
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this BugManager. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a BugManager
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		// Start the SpawnBugs Coroutine. A
		// Coroutine is used so that we can
		// use WaitForSeconds to delay spawns
		StartCoroutine(SpawnBugs());
	}

	// Controls the spawning of bugs
	IEnumerator SpawnBugs () {
		// wait for a bit at the start of the game
		yield return new WaitForSeconds(startWait);

		// Continue to spawn bugs as long as the game isn't over
		while(!GameManager.gameOver) {
			// Create a positon and rotation for a bug
			Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;

			// Determine if it will be a good bug or a bad bug
			if (Random.Range(0, badBugChance) == 0)
				// Instantiate a random bad bug into the game world
				Instantiate(badBugs[Random.Range(0, badBugs.Length)], spawnPosition, spawnRotation);
			else 
				// Instantiate a random good bug into the game world
				Instantiate(goodBugs[Random.Range(0, goodBugs.Length)], spawnPosition, spawnRotation);

			// Wait a few seconds to spawn another bug
			yield return new WaitForSeconds(spawnWait);
		}
	}

}
