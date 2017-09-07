using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Jacob Stone 8/9/17
// Script used to handle touch inputs, used to port the
// game to mobile
public class TouchInput : MonoBehaviour {

	// LayerMask for touch input on spiders
	public LayerMask touchInputMask;

	// List of touches
	private List<GameObject> touchList = new List<GameObject> ();

	// Previous touches
	private GameObject[] touchesOld;

	// A 2D raycast to help with calculations
	private RaycastHit2D hit;

	// Update is called once per frame
	void Update () {

		// TODO, also add standalone
		#if UNITY_EDITOR

		// If player clicked somewhere:
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) {

			// Handle touching the spiders
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear();

			Vector3 ray = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
			hit = Physics2D.Raycast(ray, Vector2.zero);
			if (hit != null && hit.collider != null) {

				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);

				if (Input.GetMouseButtonDown(0) && recipient.tag == "Spider") {
					recipient.SendMessage ("onTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
				}

			}

		}
			
		#endif

		// If the player touched somewhere:
		if (Input.touchCount > 0) {

			// Handle touching the spiders
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo (touchesOld);
			touchList.Clear();

			foreach (Touch touch in Input.touches) {
				
				Vector3 ray = GetComponent<Camera>().ScreenToWorldPoint(touch.position);
				hit = Physics2D.Raycast(ray, Vector2.zero);
				if (hit != null && hit.collider != null) {

					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);

					if (touch.phase == TouchPhase.Began && recipient.tag == "Spider") {
						recipient.SendMessage ("onTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
					}

				}

			}

		}
		
	}
		
}
