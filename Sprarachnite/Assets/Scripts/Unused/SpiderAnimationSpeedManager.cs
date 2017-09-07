using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the animation speeds of Spiders in the game
public class SpiderAnimationSpeedManager : MonoBehaviour {

	// The animation speed of healthy Spider
	public float healthyAnimationSpeed;

	// The animation speed of fair Spider
	public float fairAnimationSpeed;

	// The animation speed of damaged Spider
	public float damagedAnimationSpeed;

	// The animation speed of dying Spider
	public float dyingAnimationSpeed;

	// The animation speed of dead Spider
	public float deadAnimationSpeed;

	// Reference to the Moon Spider in the game
	public GameObject moonSpider;

	// Reference to the Message Spider in the game
	public GameObject messageSpider;

	// Reference to the Heart Spider in the game
	public GameObject heartSpider;

	// Reference to the Hammer Spider in the game
	public GameObject hammerSpider;

	// Reference to the Self Spider in the game
	public GameObject selfSpider;
	
	// Update is called once per frame
	void Update () {
		moonSpider.GetComponent<Animator>().speed = updateSpiderAnimationSpeed(SpiderHealthManager.moonSpiderHealthStatus);
		messageSpider.GetComponent<Animator>().speed = updateSpiderAnimationSpeed(SpiderHealthManager.messageSpiderHealthStatus);
		heartSpider.GetComponent<Animator>().speed = updateSpiderAnimationSpeed(SpiderHealthManager.heartSpiderHealthStatus);
		hammerSpider.GetComponent<Animator>().speed = updateSpiderAnimationSpeed(SpiderHealthManager.hammerSpiderHealthStatus);
		selfSpider.GetComponent<Animator>().speed = updateSpiderAnimationSpeed(SpiderHealthManager.selfSpiderHealthStatus);
	}

	// Determines an animation speed based on a Heath Status passed in
	private float updateSpiderAnimationSpeed(HealthStatus status) {
		if (status == HealthStatus.Healthy) {
			return healthyAnimationSpeed;
		} else if (status == HealthStatus.Fair) {
			return fairAnimationSpeed;
		} else if (status == HealthStatus.Damaged) {
			return damagedAnimationSpeed;
		} else if (status == HealthStatus.Dying) {
			return dyingAnimationSpeed;
		} else {
			return deadAnimationSpeed;
		}
	}

}
