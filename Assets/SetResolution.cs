using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float y = (float)(Camera.main.orthographicSize * 2.0f);
		float x = (float)(y * Screen.width / Screen.height);
		transform.localScale = new Vector3(x, y, 1);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
