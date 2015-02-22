using UnityEngine;
using System.Collections;


public class setPos : MonoBehaviour {
	private float gameWidth = 1434;
	private float gameHeight = 539;
	private Convert camToScreen;
	// Use this for initialization
	//width: 1434
	//hieght: 539
	void Start () {
//		camToScreen = new Convert (Screen.height, Screen.width);
		//transform.position = Conversion.makeFixedPoint (transform.position);
		//Debug.Log (Camera.main.ScreenToWorldPoint(new Vector3(0,0,0)));
		Camera.main.orthographicSize = Screen.height / 2;
		//transform.localScale = new Vector3 (Screen.height / 16, Screen.height / 16, 0);

	}
	void convertScreenToWorld(){
		float screenWidth = (float)Screen.width;
		float screenHeight = (float)Screen.height;
		float widthFactor = screenWidth / gameWidth;
		float heightFactor = screenHeight / gameHeight;



	}
	
	// Update is called once per frame
	void Update () {
	

	
	}
}

