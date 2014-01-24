using UnityEngine;
using System.Collections;

public class Ghetto : MonoBehaviour {

	public int jews;
	public bool open=false;
	public bool full=false;
	public int jewsInGhetto;
	public int capacity =5;
	public int openAt = 3;
	public Sprite openSprite;
	public Sprite closedSprite;

	public static Ghetto instance;

	// Use this for initialization
	void Start () {
		jews =0;
		open = false;
		jewsInGhetto=0;
		instance = this;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void markJew() {

		jews++;
		Debug.Log("Jews = " + jews);
		if (jews >= openAt && jewsInGhetto < capacity) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			open = true;
		}

	}

	public void addJew() {
		if (jewsInGhetto >= capacity) {
			full = true;
			return;
		}
		jewsInGhetto++;

		if (jewsInGhetto >= capacity) {
			full = true;
			GetComponent<SpriteRenderer>().sprite = closedSprite;
		}
	}
}

