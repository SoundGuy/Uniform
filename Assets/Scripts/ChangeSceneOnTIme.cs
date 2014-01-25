﻿using UnityEngine;
using System.Collections;

public class ChangeSceneOnTIme : MonoBehaviour {
	public float timeToChange;
	public float startTime;
	public string sceneToChange;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > timeToChange) 
			Application.LoadLevel(sceneToChange);
	}
}
