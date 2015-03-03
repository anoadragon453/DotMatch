using UnityEngine;
using System.Collections;
using System;

public class generate : MonoBehaviour {
	int cont = 1;
	public GameObject greenopp;
	public GameObject blueopp;
	Vector3 top = new Vector3(18,5.5f,0);
	Vector3 mid = new Vector3(18, 2, 0);
	Vector3 btm = new Vector3(18,-1.5f, 0);
	int rate = 600;
	int difficulty = 0;

	// Use this for initialization
	void Start () {
	
	
		//Debug.Log (runPolyAI (15));
	
	}
	/// <summary>
	/// Runs the poly AI.
	/// </summary>
	/// <returns>The poly A.</returns>
	/// <param name="time">Time.</param>


	float runPolyAI(float time){
		Vector2 term3 = new Vector2 (-0.00003f, 3);
		Vector2 term2 = new Vector2 (0.0012f, 2);
		Vector2 term1 = new Vector2 (-0.00417f, 1);
		Vector2 term0 = new Vector2 (0.3f, 0);
		Vector2[] terms = {term0, term1, term2, term3};
		float val = 0;
		foreach (Vector2 term in terms) {
			float power = (float)System.Math.Pow((double)time, term.y);
			val += term.x*power;
		}
		return 1/val;
	}

	GameObject getOpp(int rand){
		if (rand == 0)
			return greenopp;
		return blueopp;
	}
	/// <summary>
	/// Gets the position.
	/// </summary>
	/// <returns>The position.</returns>
	/// <param name="rand">Rand.</param>
	Vector3 getPos(int rand){

		if (rand == 0)
			return top;
		else if (rand == 1)
			return mid;
		return btm;
	}
	void increaseDifficulty(){
		difficulty += 1;
	}
	// Update is called once per frame
	void Update () {
		if (cont % 300==0) {
			increaseDifficulty();
			cont = 1;
			rate = (int)(60*runPolyAI(difficulty));
		}

		if (cont % rate == 0) {


			int color = UnityEngine.Random.Range (0, 2);
			int posRand = UnityEngine.Random.Range (0, 3);
			GameObject opp = getOpp (color);
			Vector3 pos = getPos (posRand);
			Instantiate (opp, pos, transform.rotation);
			Debug.Log("GENERATE rate:" + rate + "cont:" + cont + "difficulty:" + difficulty);
			//cont = 0;
		}
		
		cont++;
	
	}
}

