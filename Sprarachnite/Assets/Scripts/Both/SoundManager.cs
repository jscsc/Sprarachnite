using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to manage the sounds in the game
public class SoundManager : MonoBehaviour {

	// Static instance of SoundManager, which allows it to be accessed by any other script
	public static SoundManager instance = null;

	// AudioSource to play sound effects
	public AudioSource efxSource;

	// AudioSOurce to play music
	public AudioSource musicSource;

	// The sound for when a Spider eats a Bug
	public AudioClip spiderEatSound;

	// The sound for when a Spider is touched
	public AudioClip spiderTouchSound;

	// The sound for when a Spider dies
	public AudioClip gameOverSound;

	// The sound for when a Button is used
	public AudioClip menuSelectSound;

	// The sound for when the player misses a bug to eat
	public AudioClip bugMissSound;

	// Awake is always called before any Start functions
	void Awake() {
		
		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this SoundManager
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this SoundManager. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a SoundManager
			Destroy(gameObject);

		// Play the current scenes music
		musicSource.Play();
	}

	// Plays a single audio clip for a sound effect
	public void PlaySingle(AudioClip clip) {
		// Set the clip of our efxSource AudioSource to the clip passed in as a parameter
		efxSource.clip = clip;

		// Play the clip
		efxSource.Play();
	}

	// Plays the Menu Select sound
	public void playMenuSelectSound () {
		PlaySingle(menuSelectSound);
	}

	// Plays the Game Over sound
	public void playGameOverSound () {
		PlaySingle(gameOverSound);
	}

	// Plays the Spider Eat sound
	public void playSpiderEatSound () {
		PlaySingle(spiderEatSound);
	}

	// Plays the Spider Touch sound
	public void playSpiderTouchSound () {
		PlaySingle(spiderTouchSound);
	}

	// Plays the Bug Miss sound
	public void playBugMissSound () {
		PlaySingle(bugMissSound);
	}

	// Stops playing music for the current scene
	public void stopPlayingMusic () {
		musicSource.Stop();
	}

}
