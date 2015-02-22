using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {


	string color;
	void Start () {
		rigidbody2D.AddForce (Conversion.makeFixedPoint(new Vector3 (-300, 0, 0)));
		//this.name = ObjectName (this.name,"(Clone)");
		color = ObjectName (this.name, "Response");
	
	
	}
	string ObjectName(string name, string addon){

		int index = name.IndexOf (addon);
		string color = name.Remove (index);
		return color;
	}

	void OnCollisionEnter2D(Collision2D col){
	

		//Debug.Log (Response.placed);
		string responseColor = ObjectName (col.gameObject.name, "opp");


			if (responseColor.Equals (color)) {
				//Debug.Log ("Match");
				Destroy (gameObject);
				scoreCounter.score++;
			}
			Destroy (col.gameObject);
			if (gameObject)
				rigidbody2D.AddForce (Conversion.makeFixedPoint (new Vector3 (-300, 0, 0)));
		}

	
	// Update is called once per frame
	void Update () {
	
	}
}
