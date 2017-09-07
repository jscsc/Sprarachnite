using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Choses a Web at random to display on either the credits or rules screen
public class MenuWebPicker : MonoBehaviour {

	// Static instance of MenuWebPicker, which allows it to be accessed by any other script
	public static MenuWebPicker instance = null;

	// The webs to choose form
	public GameObject[] webs;

	// The spawn position of the credits screen web
	public Vector3 creditsWebSpawnValues;

	// The spawn position
	public Vector3 rulesWebSpawnValues;

	// The current Web in the game
	private GameObject currentWeb;

	// Awake is always called before any Start functions
	void Awake() {

		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this MenuWebPicker
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this MenuWebPicker. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a MenuWebPicker
			Destroy(gameObject);
	}

	// Picks a web to display based on the boolean passed in.
	// A value of true means a credits web, false means a rules web
	public void pickWeb (bool choice) {
		int webIndex = Random.Range(0, webs.Length);
		if (choice) {
			Vector3 creditsWebSpawnPosition = new Vector3(creditsWebSpawnValues.x, creditsWebSpawnValues.y, creditsWebSpawnValues.z);
			Quaternion creditsWebSpawnRotation = Quaternion.identity;
			currentWeb = (GameObject) Instantiate(webs[webIndex], creditsWebSpawnPosition, creditsWebSpawnRotation);
		} else {
			Vector3 rulesWebSpawnPosition = new Vector3(rulesWebSpawnValues.x, rulesWebSpawnValues.y, rulesWebSpawnValues.z);
			Quaternion rulesWebSpawnRotation = Quaternion.identity;
			currentWeb = (GameObject) Instantiate(webs[webIndex], rulesWebSpawnPosition , rulesWebSpawnRotation);
		}
	}

	// Removes the current web from the game
	public void removeWeb () {
		if(currentWeb != null)
			Destroy(currentWeb);
	}
}
