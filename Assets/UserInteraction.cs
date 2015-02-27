using UnityEngine;
using System.Collections;

public class UserInteraction : MonoBehaviour {

	// ----------------- Doubleclick detection ---------------- //
	bool mouseClicksStarted = false;
	int mouseClicks = 0;
	float mouseTimerLimit = .2f;
	bool singleClickInitiated = false;

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

	// ------------------- Sprite Variables ------------------- //
	public Sprite greenColor;
	public Sprite blueColor;
	 

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
			isMoving = true;
			temp = new Vector3(movementVelocity,0,0);
			transform.position += temp;
		} else {
			Debug.Log("Single Clicked");
			switchDotColor();
		}
		mouseClicksStarted = false;
		mouseClicks = 0;
	}

	private void switchDotColor()
	{
		if (gameObject.GetComponent<SpriteRenderer> ().sprite == greenColor as Sprite) {
			gameObject.GetComponent<SpriteRenderer> ().sprite = blueColor as Sprite;
		} else {
			gameObject.GetComponent<SpriteRenderer> ().sprite = greenColor as Sprite;
		}
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

		if (singleClickInitiated) {
			singleClickInitiated = true;
		}
	}
}
