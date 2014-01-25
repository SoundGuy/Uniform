using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public static GameState instance;
	public int [] jewsInGhetto;
	public int currentGhetto;

	// Use this for initialization
	void Start () {
		Debug.Log("Game State Start Called");
		instance = this;
		DontDestroyOnLoad(this);
		jewsInGhetto = new int[6];
		for (int j=0;j< 6;j++) {
			jewsInGhetto[j]=0;
		}

		currentGhetto = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
