using UnityEngine;
using System.Collections;

public class ShowerHandle : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1") &&  GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(vec.x,vec.y))) {
			// start cleanse
			Debug.Log("Gas!!");

			GetComponent<Animator>().SetBool("IsIdle",false);
			Camp.instance.KillJews();

		}
	}
}
