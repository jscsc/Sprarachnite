using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Choses a quote at random to display on the main menu
public class MenuQuotePicker : MonoBehaviour {

	// Struct to store quotes in
	// Serializable to be visible in inspector
	[System.Serializable]
	public struct Quote {
		public string statement;
		public string author;
	}

	// Static instance of MenuQuotePicker, which allows it ot be accessed by any other script
	public static MenuQuotePicker instance = null;

	// Array of quotes to use
	public Quote[] quotes;

	// The UI text to display the statement on
	public Text statementText;

	// The UI text to display the author on
	public Text authorText;

	// Awake is always called before any Start functions
	void Awake() {

		// Check if instance already exists:
		if (instance == null)
			// If not, set instance to this MenuQuotePicker
			instance = this;

		// If instance already exists and it's not this:
		if (instance != this)
			// Then destroy this MenuQuotePicker. This enforces our singleton pattern, meaning
			// there can only ever be one instance of a MenuQuotePicker
			Destroy(gameObject);

	}

	// Chooses a quote at random and displays it on the menu
	public void pickQuote () {
		int quoteIndex = Random.Range(0, quotes.Length);
		statementText.text = quotes[quoteIndex].statement;
		authorText.text = quotes[quoteIndex].author;
	}

}

