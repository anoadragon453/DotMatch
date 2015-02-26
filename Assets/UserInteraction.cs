using UnityEngine;
using System.Collections;

public class UserInteraction : MonoBehaviour {

	// ----------------- Doubleclick detection ---------------- //
	bool mouseClicksStarted = false;
	int mouseClicks = 0;
	float mouseTimerLimit = .2f;
	bool doubleClickInitiated = false;

	// --- Determine whether this is for user or AI Objects --- //
	bool isUserObject = true; // Ball will fly to right or left based on this bool
	bool isMoving = false;

	// ------------------- Moving Variables ------------------- //
	float movementVelocity = 3.0f;
	Vector3 temp;

	// ------------------ Shrinking Variables ----------------- //
	float minSize = 5f;
	float shrinkRate = 1.0f;
	float scale = 48.0f;
	 

	void Start () {
		// Scale object depending on screen size.
		transform.localScale = new Vector3(Screen.height/16, Screen.height/16,
0);
		transform.position = Conversion.makeFixedPoint(transform.position);
	}

	void OnMouseDown() {
		mouseClicks++;
		if (mouseClicksStarted) {
			return;
		}
		mouseClicksStarted = true;
		Invoke("checkMouseDoubleClick", mouseTimerLimit);
	}


	private void checkMouseDoubleClick()
	{
		if (mouseClicks > 1) {
			Debug.Log("Double Clicked");
			doubleClickInitiated = true;
		} else {
			Debug.Log("Single Clicked");
			isMoving = true;
			temp = new Vector3(movementVelocity,0,0);
			transform.position += temp;
		}
		mouseClicksStarted = false;
		mouseClicks = 0;
	}

	// Update is called once per frame
	void Update () {
		if (isMoving) {
		    if (isUserObject) {
		        transform.position += temp;
		    } else {
		        transform.position -= temp;
		    }
		}

		if (doubleClickInitiated) {
			transform.localScale = Vector3.one * scale;
	     	scale -= shrinkRate * Time.deltaTime * 80.0f; // Since objects are so large in the game space.
	     	if (scale < minSize) Destroy (gameObject);
		}
	}
}
