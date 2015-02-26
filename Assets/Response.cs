using UnityEngine;
using System.Collections;

public class Response : MonoBehaviour {
	public  bool placed = false;
	
	string color;
	int go = 0;
	private Vector3 mousePosition;
	private float moveSpeed = 1.0f;
	Vector3 top = Conversion.makeFixedPoint(new Vector3(-15,5.5f,0));
	Vector3 mid = Conversion.makeFixedPoint(new Vector3(-15, 2, 0));

	Vector3 btm = Conversion.makeFixedPoint(new Vector3(-15,-1.5f, 0));
	// Use this for initialization

	
	
	void Start(){
		//rigidbody.AddForce (900, 0, 0);
		transform.position = Conversion.makeFixedPoint (transform.position);
		transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
		color = ObjectName (this.name, "Response");

	}
	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	
	void OnMouseDown(){
	//	Debug.Log ("ypos"+transform.position.y);
		placed = true;
		go++;
	}
	/// <summary>
	/// Shoulds the I kill myself.
	/// </summary>
	/// <returns><c>true</c>, if I kill myself was shoulded, <c>false</c> otherwise.</returns>
	/// <param name="pos">Position.</param>
	bool ShouldIKillMyself(Vector3 pos){
		float y = pos.y;
		float maxY = Conversion.makeFixedPoint (new Vector3(0, -4, 0)).y;
		//Debug.Log ("btm" + (btm.;
		if (y < maxY)
			return true;
		return false;
	}
	/// <summary>
	/// Objects the name.
	/// </summary>
	/// <returns>The name.</returns>
	/// <param name="name">Name.</param>
	/// <param name="addon">Addon.</param>
	string ObjectName(string name, string addon){
		
		int index = name.IndexOf (addon);
		string color = name.Remove (index);
		return color;
	}
	/// <summary>
	/// Determines the lane.
	/// </summary>
	/// <returns>The lane.</returns>
	/// <param name="pos">Position.</param>
	Vector3 determineLane(Vector3 pos){
		//pos = Conversion.makeFixedPoint (pos);
		float y = pos.y;
		//Vector3 lane;
		if (y > (top.y+mid.y)/2.0f)
			return top;
		else if (y <= (top.y+mid.y)/2.0f && y > (mid.y+btm.y)/2.0f)
			return mid;

		
		return btm;
		//return lane;
	}
	/// <summary>
	/// Raises the collision enter2 d event.
	/// </summary>
	/// <param name="col">Col.</param>

	void OnCollisionEnter2D(Collision2D col){
		if (placed) {
		
			//Debug.Log (Response.placed);
			string responseColor = ObjectName (col.gameObject.name, "opp");
		
		
			if (responseColor.Equals (color)) {
				//Debug.Log ("Match");
				Destroy (col.gameObject);
				scoreCounter.score++;
			}
			Destroy (gameObject);
			if (col.gameObject)
				col.gameObject.rigidbody2D.AddForce (Conversion.makeFixedPoint (new Vector3 (-300, 0, 0)));
		}
	}

	
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		if (!placed) {
		//	Debug.Log ("movin");
			//rigidbody2D.isKinematic = true;
			//rigidbody2D.simulated = false;

			rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.None;
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
			transform.position = Vector2.Lerp (mousePosition, mousePosition, moveSpeed);

		} else if (go == 1) {
			//rigidbody2D.simulated = true;
			rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
			rigidbody2D.mass = 1;
			if(ShouldIKillMyself(transform.position))
			   Destroy(gameObject);
			transform.position = determineLane(transform.position);
			rigidbody2D.AddForce (Conversion.makeFixedPoint(new Vector3 (300, 	0, 0)));
			go++;
		}
		
	}
}
