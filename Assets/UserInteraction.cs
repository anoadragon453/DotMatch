using UnityEngine;
using System.Collections;

public class UserInteraction : MonoBehaviour {

	// ------------------- Doubleclick detection ------------------- //
	bool mouseClicksStarted = false;
	int mouseClicks = 0;
	float mouseTimerLimit = .2f;

	// ------------------- Determine whether this is for user or AI Objects ------------------- //
	bool isUserObject = true; // Ball will fly to right or left based on this bool
	bool isMoving = false;

	//
	Vector3 temp;

	//
	bool doubleClickInitiated = false;
	float minSize = .1f;
	float shrinkRate = .7f;
	float scale = .5f;
	 

	void Start () {

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
			temp = new Vector3(0.1f,0,0);
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
	     	scale -= shrinkRate * Time.deltaTime;
	     	if (scale < minSize) Destroy (gameObject);
		}
	}
}
