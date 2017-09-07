using UnityEngine;
using System.Collections;

// Author: Jacob Stone 1/16/17
// Script to change the size of orthographic camera so that
// At every resolution and aspect ratio, there will always be
// The same amount of room btween the Spiders and the edge of
// the play window
[ExecuteInEditMode]
public class ScaleWidthCamera : MonoBehaviour {

	// Target width of the game
	public int targetWidth = 640;

	// pixels per units to calculate with
	public float pixelsToUnits = 100;

	// The camera attached to this game object (the main camera)
	private Camera gameplayCamera;

	// Used for initialization
	void Start () {
		// Set the camrea reference
		gameplayCamera = this.gameObject.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		// Calulcate the hight and perform the calculation
		int height = Mathf.RoundToInt(targetWidth / (float)Screen.width * Screen.height);
		gameplayCamera.orthographicSize = height / pixelsToUnits / 2;
		
	}
}
