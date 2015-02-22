using UnityEngine;

using System.Collections;

public class scoreCounter : MonoBehaviour {
	public static int score;
	// Use this for initialization


	void Start () {
		Conversion conv = new Conversion (Screen.height, Screen.width);

		Debug.Log (transform.position);
		score = 0;

	
		transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);
		transform.position = conv.makeFixedPoint (transform.position);
		Debug.Log (transform.position);

	}
	public void setScore(int score){
		string scoreString = score.ToString ();
		GetComponent<TextMesh> ().text = scoreString;
	}

	// Update is called once per frame
	void Update () {
		setScore (score);
	}
}
