using UnityEngine;
using System.Collections;

public class launch : MonoBehaviour {
	string color;
	// Use this for initialization
	public GameObject response;
	void Start () {
		color = ObjectName ();
		transform.position = Conversion.makeFixedPoint (transform.position);
		transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
		Debug.Log ("launch pos" + transform.position);

		Debug.Log ("sphere colllider" + GetComponent<CircleCollider2D> ().transform.position);

	
	}

	string ObjectName(){
		string name = this.name;
		int index = name.IndexOf ("Launch");
		string color = name.Remove (index);
		return color;
	}
	void OnMouseDown(){
		//Debug.Log ("clciked" + Input.mousePosition);
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, 10);
		GameObject resp = (GameObject)Instantiate(response, transform.position , transform.rotation);
		resp.name =  color + "Response";
		//Debug.Log (resp.name);

	}
	
	// Update is called once per frame
	void Update () {
	


	}
}
