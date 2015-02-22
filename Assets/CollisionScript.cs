using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour {


	string color;
	void Start () {
		rigidbody.AddForce (new Vector3 (-900, 0, 0));
		color = ObjectName (this.name,"opp");
		//transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
	
	}
	string ObjectName(string name, string addon){

		int index = name.IndexOf (addon);
		string color = name.Remove (index);
		return color;
	}

	void OnCollisionEnter(Collision col){
		string responseColor = ObjectName (col.gameObject.name, "Response");
		if (responseColor.Equals (color)) {
			Destroy (gameObject);
			scoreCounter.score++;
		}
		Destroy (col.gameObject);
		if (gameObject)
			rigidbody.AddForce (-900, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
