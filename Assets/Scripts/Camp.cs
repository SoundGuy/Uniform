using UnityEngine;
using System.Collections;

public class Camp : MonoBehaviour {

	public Ghetto [] ghettos;


	// Use this for initialization
	void Start () {

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TrainUnloaded() {
		UILabel label = GameObject.Find("Instructions").GetComponent<UILabel>();
		label.text = "Cleanse";
	}
}
