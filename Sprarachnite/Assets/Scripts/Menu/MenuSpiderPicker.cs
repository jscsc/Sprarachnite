using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Chooses a Spider at random to display on the main menu
public class MenuSpiderPicker : MonoBehaviour {

	// Static instance of MenuSpiderPicker, which allows it to be accessed by any other script
	public static MenuSpiderPicker instance = null;

	// The Spiders to choose from
	public GameObject[] spiders;

	// The spawn values for the Spiders
	public Vector3 spiderSpawnValues;

	// The current Spider that is picked
	private GameObject currentSpider;

	// Awake is always called before any Start functions
	void Awake() {

		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this MenuSpiderPicker
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this MenuSpiderPicker. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a MenuSpiderPicker
			Destroy(gameObject);
	}

	// Picks a Spider and displays it on the main menu
	public void pickSpider () {
		int spiderIndex = Random.Range(0, spiders.Length);
		Vector3 spawnPosition = new Vector3(spiderSpawnValues.x, spiderSpawnValues.y, spiderSpawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		currentSpider = (GameObject) Instantiate(spiders[spiderIndex], spawnPosition , spawnRotation);
	}

	// Removes the current spider from the main menu
	public void removeSpider () {
		if (currentSpider != null)
			Destroy(currentSpider);
	}
}
