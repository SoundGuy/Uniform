using UnityEngine;
using System.Collections;

public class ObejctFactory : MonoBehaviour {

	public int numberOfGoods;
	public GameObject GoodPF;
	public int numberOffBads;
	public GameObject BadPF;
	// Use this for initialization
	void Start () {

		createPeople ();
	
	
	}


	Vector3 RandPosition(){
		return new Vector3 (Random.Range (-7f, 7f), Random.Range (-5f, 5f), 0f);

		// make sure position is outside Ghetto.
	}

	void createPeople () {
		// create good.
		for (int i=0; i<numberOfGoods; i++) {
						Instantiate (GoodPF, RandPosition (), Quaternion.identity);
		}

		// create bad.
		for (int i=0; i<numberOffBads; i++) {
			Instantiate (BadPF, RandPosition (), Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
