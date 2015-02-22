using UnityEngine;
using System.Collections;

public class generate : MonoBehaviour {
	int cont = 1;
	public GameObject greenopp;
	public GameObject blueopp;
	Vector3 top = new Vector3(18,5.5f,0);
	Vector3 mid = new Vector3(18, 2, 0);
	Vector3 btm = new Vector3(18,-1.5f, 0);

	// Use this for initialization
	void Start () {
	

	
	}

	GameObject getOpp(int rand){
		if (rand == 0)
			return greenopp;
		return blueopp;
	}

	Vector3 getPos(int rand){
		if (rand == 0)
			return top;
		else if (rand == 1)
			return mid;
		return btm;
	}
	// Update is called once per frame
	void Update () {
		if (cont % 240 == 0) {
			int color = Random.Range(0,2);
			int posRand = Random.Range(0,3);
			GameObject opp = getOpp(color);
			Vector3 pos = getPos(posRand);
			Instantiate(opp,pos,transform.rotation);
			cont = 0;
		}
		cont++;
	
	}
}
