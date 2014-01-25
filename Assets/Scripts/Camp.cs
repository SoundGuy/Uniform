using UnityEngine;
using System.Collections;

public class Camp : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TrainUnloaded() {
		UILabel label = GameObject.Find("Instructions").GetComponent<UILabel>();
		label.text = "Cleanse";
	}
}
