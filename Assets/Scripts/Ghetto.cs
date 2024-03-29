﻿using UnityEngine;
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
	public int ghettoIndex;

	public static Ghetto instance;

	UILabel label;

	// Use this for initialization
	void Start () {
		jews =0;
		open = false;
		jewsInGhetto=0;
		instance = this;

		label = GameObject.Find("Instructions").GetComponent<UILabel>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (full && Input.GetAxis("Mouse ScrollWheel") < 0f && Application.loadedLevelName == "Ghetto") {
			Application.LoadLevel("camp");
		}
	
	}

	public void markJew() {

		jews++;
//		Debug.Log("Jews = " + jews);
		if (jews >= openAt && jewsInGhetto < capacity) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			open = true;

			label.text = "Contain Threats";
		}

	}

	public void addJew() {
		if (jewsInGhetto >= capacity) {
			full = true;
			return;
		}
		jewsInGhetto++;
		GameState.instance.jewsInGhetto[GameState.instance.currentGhetto] = jewsInGhetto;

		if (jewsInGhetto >= capacity) {
			full = true;
			GetComponent<SpriteRenderer>().sprite = closedSprite;
			label.text = "Scroll to zoom";
			Application.LoadLevel("LevelPassPoster");
		}
	}
}

