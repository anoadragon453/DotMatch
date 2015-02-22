using UnityEngine;
using System.Collections;

public class adaptPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.position = Conversion.makeFixedPoint (transform.position);
		transform.localScale = new Vector3 (Screen.width / 8, Screen.height / 64, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
