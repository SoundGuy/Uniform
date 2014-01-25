using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camp : MonoBehaviour {

	public Ghetto [] ghettos;
	public GameObject shower;
	public GameObject showerHandle;
	public List<GameObject> jewsInCamp;

	public static Camp instance;

	// Use this for initialization
	void Start () {
		instance = this;

		ghettos = new Ghetto[6];
		int i=0;
		Ghetto [] ghettoObjs =  GameObject.FindObjectsOfType<Ghetto>();
		CampGhetto [] campGhettoObjs =  GameObject.FindObjectsOfType<CampGhetto>();
		Debug.Log("ghettos = " + ghettoObjs.Length + " campghettos " + campGhettoObjs.Length);
		foreach (Ghetto gt in ghettoObjs) {
			gt.ghettoIndex = i; // Do you really want to do this every time?
			campGhettoObjs[i].campGhettoIdx = i;
			//Debug.Log("i= " +i);
			if(GameState.instance) {
				int jewsToAdd = GameState.instance.jewsInGhetto[i];
				gt.jewsInGhetto = jewsToAdd;
				if (gt.jewsInGhetto >= gt.capacity) 
					gt.full = true;
				else
					gt.full = false;
			}
			campGhettoObjs[i].initJews();

			i++;
		}
	

		jewsInCamp = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TrainUnloaded() {
		UILabel label = GameObject.Find("Instructions").GetComponent<UILabel>();
		label.text = "Cleanse";

		shower.SetActive(true);
		showerHandle.SetActive(true);
	}


	public void KillJews() {
		foreach(GameObject jew in jewsInCamp) {
			Destroy(jew);
		}

		if (GameState.instance)
			GameState.instance.Score += 1050000 + Random.Range(-20000,20000);
	}

}
