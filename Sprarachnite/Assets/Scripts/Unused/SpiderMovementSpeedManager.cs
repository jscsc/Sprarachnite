using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the movement speed of Spiders in the game
public class SpiderMovementSpeedManager : MonoBehaviour {

	// Static instance of SpiderMovementSpeedManager, which allows it to be accessed by
	// any other script
	public static SpiderMovementSpeedManager instance = null;

	// The movement speed of a healthy Spider
	public float healtyMovementSpeed;

	// The movement speed of a fair Spider
	public float fairSpiderMovementSpeed;

	// The movement speed of a damaged Spider
	public float damagedMovementSpeed;

	// The movement speed of a dying Spider
	public float dyingMovementSpeed;

	// The movement speed of a dead Spider
	public float deadMovementSpeed;

	// Awake is always called before any Start functions
	void Awake() {
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this GameManger
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this GameManger. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a GameManager
			Destroy(gameObject);
	}

	// Sets the speed of a Spider determined by the Category passed in
	public float setSpiderSpeed (Category spiderCategory) {
		// Switch to decide which Spider to set the speed of
		switch(spiderCategory) {
			case Category.Moon:
				return getSpiderSpeedByHealth(SpiderHealthManager.moonSpiderHealthStatus);
			case Category.Message:
				return getSpiderSpeedByHealth(SpiderHealthManager.messageSpiderHealthStatus);
			case Category.Heart:
				return getSpiderSpeedByHealth(SpiderHealthManager.heartSpiderHealthStatus);
			case Category.Hammer:
				return getSpiderSpeedByHealth(SpiderHealthManager.hammerSpiderHealthStatus);
			case Category.Self:
				return getSpiderSpeedByHealth(SpiderHealthManager.selfSpiderHealthStatus);
			default:
				return 0.0f;
		}
	}

	// returns a movement speed based on the HealthStatus passed in
	private float getSpiderSpeedByHealth(HealthStatus status) {
		// Switch to determine which speed to return
		switch(status) {
			case HealthStatus.Healthy:
				return healtyMovementSpeed;
			case HealthStatus.Fair:
				return fairSpiderMovementSpeed;
			case HealthStatus.Damaged:
				return damagedMovementSpeed;
			case HealthStatus.Dying:
				return dyingMovementSpeed;
			case HealthStatus.Dead:
				return deadMovementSpeed;
			default:
				return 0.0f;
		}
	}
}
