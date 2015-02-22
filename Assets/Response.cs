using UnityEngine;
using System.Collections;

public class Response : MonoBehaviour {
	bool placed = false;
	int go = 0;
	private Vector3 mousePosition;
	private float moveSpeed = 1.0f;
	Vector3 top = new Vector3(-15,5.5f,0);
	Vector3 mid = new Vector3(-15, 2, 0);
	Vector3 btm = new Vector3(-15,-1.5f, 0);
	// Use this for initialization
	
	
	void Start(){
		//rigidbody.AddForce (900, 0, 0);
		//transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
	}
	
	void OnMouseDown(){
		placed = true;
		go++;
	}
	bool ShouldIKillMyself(Vector3 pos){
		float y = pos.y;
		if (y < -3)
			return true;
		return false;
	}
	Vector3 determineLane(Vector3 pos){
		float y = pos.y;
		//Vector3 lane;
		if (y > 2.75f)
			return top;
		else if (y <= 2.75f && y > .25f)
			return mid;

		
		return btm;
		//return lane;
	}
	
	// Update is called once per frame
	void Update () {
		if (!placed) {
		//	Debug.Log ("movin");
			rigidbody.detectCollisions = false;
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			transform.position = Vector2.Lerp (mousePosition, mousePosition, moveSpeed);

		} else if (go == 1) {
			rigidbody.detectCollisions = true;
			if(ShouldIKillMyself(transform.position))
			   Destroy(gameObject);
			transform.position = determineLane(transform.position);
			rigidbody.AddForce (new Vector3 (900, 0, 0));
			go++;
		}
		
	}
}
