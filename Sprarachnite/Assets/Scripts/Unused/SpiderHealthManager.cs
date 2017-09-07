using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage Spider health values in the game
public class SpiderHealthManager : MonoBehaviour {

	// Max health for spiders
	public int maxSpiderHealth;

	// The amount to decrease health by
	public int heathDecreaseValue;

	// The Boundary between healthy and fair health values
	public int healthyBoundary;

	// The Boundary between fair and damaged health values
	public int fairBoundary;

	// The Boundary between damaged and dying health values
	public int damagedBoundary;

	// The Boundary between dying and dead health values
	public int dyingBoundary;

	// The rate in which to decrease spider health by in seconds
	public float secondsBetweenHealthDecreases;

	// Health for the moon spider
	private static int moonSpiderHealth;

	// Health for the message spider
	private static int messageSpiderHealth;

	// Health for the heart spider
	private static int heartSpiderHealth;

	// Health for the hammer spider
	private static int hammerSpiderHealth;

	// Health for the self spider
	private static int selfSpiderHealth;

	// Health Status for the moon spider
	public static HealthStatus moonSpiderHealthStatus = HealthStatus.Healthy;

	// Health Status for the message spider
	public static HealthStatus messageSpiderHealthStatus = HealthStatus.Healthy;

	// Health Status for the heart spider
	public static HealthStatus heartSpiderHealthStatus =  HealthStatus.Healthy;

	// Health Status for the hammer spider
	public static HealthStatus hammerSpiderHealthStatus =  HealthStatus.Healthy;

	// Health Status for the self spider
	public static HealthStatus selfSpiderHealthStatus = HealthStatus.Healthy;

	// Use this for initialization
	void Start () {
		// Set all the Spiders to max health
		moonSpiderHealth = maxSpiderHealth;
		messageSpiderHealth = maxSpiderHealth;
		heartSpiderHealth = maxSpiderHealth;
		hammerSpiderHealth = maxSpiderHealth;
		selfSpiderHealth = maxSpiderHealth;

		// Make the decreaseSpiderHelaths() function repeat by a designer specified value
		InvokeRepeating("decreaseSpiderHealths", secondsBetweenHealthDecreases, secondsBetweenHealthDecreases);
	}

	// Called after all Update functions have been called
	void LateUpdate () {
		// If the game is not over, get a new health status for every Spider
		if (!GameManager.gameOver) {
			moonSpiderHealthStatus = setHeathStatus(moonSpiderHealth, Category.Moon);
			messageSpiderHealthStatus = setHeathStatus(messageSpiderHealth, Category.Message);
			heartSpiderHealthStatus = setHeathStatus(heartSpiderHealth, Category.Heart);
			hammerSpiderHealthStatus = setHeathStatus(hammerSpiderHealth, Category.Hammer);
			selfSpiderHealthStatus = setHeathStatus(selfSpiderHealth, Category.Self);	
		}
	}

	// Returns a HealthStatus for a given healthValue
	private HealthStatus setHeathStatus (int healthValue, Category callerCategory) {

		//Determine which HealthStatus to return with if-else statements
		if (healthValue >= healthyBoundary) {
			return HealthStatus.Healthy;
		} else if (healthValue >= fairBoundary && healthValue < healthyBoundary) {
			return HealthStatus.Fair;
		} else if (healthValue >= damagedBoundary && healthValue < fairBoundary) {
			return HealthStatus.Damaged;
		} else if (healthValue >= dyingBoundary && healthValue < damagedBoundary) {
			return HealthStatus.Dying;
		} else {
			// The caller of this function is now dead, set the game over message and signal the end of the game
			GameOverDisplayer.instance.setGameOverMessageText ("The " + callerCategory + " spider starved");
			SoundManager.instance.playGameOverSound();
			GameManager.gameOver = true;
			return HealthStatus.Dead;
		}
	}

	// Returns the value passed in if it is above zero, otherwise
	// it returns zero
	private int checkValueBelowZero(int value) {
		if (value < 0)
			return 0;
		else
			return value;
	}

	// Decreases each spiders health by designer specified value
	void decreaseSpiderHealths () {
		moonSpiderHealth -= heathDecreaseValue;
		messageSpiderHealth -= heathDecreaseValue;
		heartSpiderHealth -= heathDecreaseValue;
		hammerSpiderHealth -= heathDecreaseValue;
		selfSpiderHealth -= heathDecreaseValue;

		// Set every Spider's health that is below zero back to zero
		moonSpiderHealth = checkValueBelowZero(moonSpiderHealth);
		messageSpiderHealth = checkValueBelowZero(messageSpiderHealth);
		heartSpiderHealth = checkValueBelowZero(heartSpiderHealth);
		hammerSpiderHealth = checkValueBelowZero(hammerSpiderHealth);
		selfSpiderHealth = checkValueBelowZero(selfSpiderHealth);
			
	}

	// Adds passed in health value to a Spider determined by the Category passed in
	public static void AddSpiderHealth (int healthIncrease, Category spiderCategory) {
		switch(spiderCategory) {
			case Category.Moon:
				moonSpiderHealth += healthIncrease;
				break;
			case Category.Message:
				messageSpiderHealth += healthIncrease;
				break;
			case Category.Heart:
				heartSpiderHealth += healthIncrease;
				break;
			case Category.Hammer:
				hammerSpiderHealth += healthIncrease;
				break;
			case Category.Self:
				selfSpiderHealth += healthIncrease;
				break;
			default:
				break;
		}
	}

	// Sets all the Spiders in the game to the Dead healthStatus
	public static void killSpiders () {
		moonSpiderHealthStatus = HealthStatus.Dead;
		messageSpiderHealthStatus = HealthStatus.Dead;
		heartSpiderHealthStatus = HealthStatus.Dead;
		hammerSpiderHealthStatus = HealthStatus.Dead;
		selfSpiderHealthStatus = HealthStatus.Dead;
	}

}

// Enum for Spider health state
public enum HealthStatus {Healthy, Fair, Damaged, Dying, Dead};
