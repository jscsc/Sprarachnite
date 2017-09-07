using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to randomly position Spiders at the start of the game
public class SpiderPositioner : MonoBehaviour {

	// Static instance of SpiderPositioner, which allows it to be accessed by any other script.
	public static SpiderPositioner instance = null;
	
	// The first positon for spiders
	public float firstSpiderPosition;

	// The second positon for spiders
	public float secondSpiderPosition;

	// The third positon for spiders
	public float thirdSpiderPosition;

	// The fourth positon for spiders
	public float fourthSpiderPosition;

	// The fifth positon for spiders
	public float fifthSpiderPosition;

	// The moon spider in the game
	public GameObject moonSpider;

	// The moon spider in the game
	public GameObject messageSpider;

	// The moon spider in the game
	public GameObject heartSpider;

	// The moon spider in the game
	public GameObject hammerSpider;

	// The moon spider in the game
	public GameObject selfSpider;

	// an array of the spiders in the game
	public static GameObject[] spiders;


	// Use this for initialization
	void Awake () {
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this SpiderPositioner
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this SpiderPositioner. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a SpiderPositioner
			Destroy(gameObject);

		// Initializee the spiders array
		spiders = new GameObject[5];
		spiders[0] = moonSpider;
		spiders[1] = messageSpider;
		spiders[2] = heartSpider;
		spiders[3] = hammerSpider;
		spiders[4] = selfSpider;

		positionSpiders ();
	}

	// Handles the act of giving spiders a new position
	public void positionSpiders () {
		// Randomize the Spider order
		randomizeSpiderOrder();
		// Assign new x-axis positions to Spiders
		assginNewHorizontalPositions();
	}

	// Randomizes the new position for Spiders in the spiders array
	private void randomizeSpiderOrder () {
		GameObject temp = null;
		int ranIndex = 0;
		for(int i = 0; i < spiders.Length; i++) {
			ranIndex = Random.Range(0, spiders.Length);
			temp = spiders[i];
			spiders[i] = spiders[ranIndex];
			spiders[ranIndex] = temp;
		}
	}

	// Assigns the new horizontal positions to spiders based on
	// their position in the spider array
	private void assginNewHorizontalPositions () {
		spiders[0].transform.position = new Vector3(firstSpiderPosition, spiders[0].transform.position.y, spiders[0].transform.position.z);
		spiders[1].transform.position = new Vector3(secondSpiderPosition, spiders[1].transform.position.y, spiders[1].transform.position.z);
		spiders[2].transform.position = new Vector3(thirdSpiderPosition, spiders[2].transform.position.y, spiders[2].transform.position.z);
		spiders[3].transform.position = new Vector3(fourthSpiderPosition, spiders[3].transform.position.y, spiders[3].transform.position.z);
		spiders[4].transform.position = new Vector3(fifthSpiderPosition, spiders[4].transform.position.y, spiders[4].transform.position.z);
	}

}
