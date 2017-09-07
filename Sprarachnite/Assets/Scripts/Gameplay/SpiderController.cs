using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to control the indiviudal aspects of Spiders in the game.
public class SpiderController : MonoBehaviour {

	// The state that the Spider is currently in
	private SpiderState state;

	// The type this Spider is
	public Category spiderCategory = Category.All;

	// The speed at which this Spider will move
	//private float speed;

	// Boolean to determine if this Spider's state in the
	// last update was Stationary for efficiency
	private bool wasStationaryLastUpdate;

	// Use this for initialization
	void Start () {
		// Start the spider in the stationary state
		state = SpiderState.Stationary;
	}
	
	// Update is called once per frame.
	// Determines the state of the spider
	// and moves it accordingly
	void Update () {

		// If the game is not over:
		if (!GameManager.gameOver) {

			// Switch behavior based on the state of this Spider
			switch (state) {
				case SpiderState.Descending:
					// Move the Spider down according to the speed
					transform.Translate (Vector3.down * SpiderManager.instance.spiderSpeed * Time.deltaTime);
					break;
				case SpiderState.Ascending:
					// Move the Spider up according to the speed.
				transform.Translate (Vector3.up * SpiderManager.instance.spiderSpeed * Time.deltaTime);
					// Singal to the next Update() that the Spider'state was not
					// Stationary in this call to Update()
					wasStationaryLastUpdate = false;
					break;
				case SpiderState.Stationary:
					// If this Spider's state was not Stationary in the last update:
					if (!wasStationaryLastUpdate) {
						// Reset it's vertical postion to the default position
						transform.position = new Vector3 (transform.position.x, GameManager.instance.defaultSpiderHeight, transform.position.z);
						// Singal to the next Update() that the Spider'state was
						// Stationary in this call to Update()
						wasStationaryLastUpdate = true;
					}
					break;
				default:
					// Do nothing
					break;
			}
			
		}

	}

	// Responds to the player touching the spider
	void onTouchDown () {
		moveSpider();
	}

	public void moveSpider () {
		// If the Spider's state is Stationary and the game is not over:
		if (state == SpiderState.Stationary && !GameManager.gameOver) {
			// Signal the Spider to move downward by changing its state to Descending
			SoundManager.instance.playSpiderTouchSound();
			state = SpiderState.Descending;
		}
	}

	// Called when the Spider collides with another 2D GameObject (with a trigger)
	void OnTriggerEnter2D (Collider2D coll) {

		// Switch on the tag of the game object hit
		switch(coll.gameObject.tag) {
			case "GameplayGround":
				// Change state of this Spider to Ascending so it will
				// move back up the web
				state = SpiderState.Ascending;
				break;
			case "GameplayCeiling":
				// Change state of this Spider to Stationary so it
				// may be used again by the player
				state = SpiderState.Stationary;
				break;
			case "GoodBug":
				// Change state of this Spider to Ascending
				state = SpiderState.Ascending;

				// Handle health and score updates in the GameManager
				GameManager.instance.handleGoodBugInteraction(this.gameObject, coll.gameObject);
				break;
			case "BadBug":
				// Handle consequences in the GameManager
				GameManager.instance.handleBadBugInteraction();
				break;
			default:
				break;
		}
	}

}

// Enum for Spider movement state
enum SpiderState {Ascending, Descending, Stationary};

// Enum for World Object category
public enum Category {Moon, Message, Heart, Hammer, Self, All};
