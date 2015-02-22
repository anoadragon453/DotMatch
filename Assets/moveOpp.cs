using UnityEngine;
using System.Collections;

public class moveOpp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (Conversion.makeFixedPoint(new Vector3 (-300, 0, 0)));
		this.name = ObjectName (this.name,"(Clone)");
		transform.position = Conversion.makeFixedPoint (transform.position);
		transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
	
	}
	string ObjectName(string name, string addon){
		
		int index = name.IndexOf (addon);
		string color = name.Remove (index);
		return color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
