using UnityEngine;
using System.Collections;

public class TurnToYellow : MonoBehaviour {

	public Sprite yellow;
	public bool isYellow=false;
	public bool imSelected = false;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) {
			//Debug.Log("Fire1");

			// PC
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
			if (hit) {
				//Debug.Log("Ray" + hit.collider.name);
				if (hit.collider.gameObject == this.gameObject) {
					//Debug.Log("Hit!" + hit);
					SpriteRenderer sr = GetComponent<SpriteRenderer>();
					sr.sprite = yellow;
					imSelected = true;

					Ghetto.instance.markJew();
															
				}		
			}
		}

		if (Input.GetButtonUp("Fire1")) {
			//Debug.Log ("Up + " + imSelected);
			if (canSelect()) {

				Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if (Ghetto.instance.GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(vec.x,vec.y))) {
					Ghetto.instance.addJew();
				}

				// PC
				/*
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
				if (hit) {
					Debug.Log("UpRay " + hit.collider.name);
					if (hit.collider.gameObject.name == "GhettoInner") {
						Debug.Log("InGhetto" + hit);

						transform.position = hit.collider.transform.position;
						//Ghetto gt = hit.collider.GetComponent<Ghetto>();
						//gt.addJew();
					}		
				}*/
			}
			imSelected = false;
		}

		//LineRenderer lr = GetComponent<LineRenderer>();
		if (canSelect()) {
		//	lr.enabled = true;
		//	lr.SetPosition(0,transform.position);
		//	lr.SetPosition(1,Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			pos.z=0;
			transform.position = pos;
		} else {
		//	lr.enabled = false;
		}

	}

	bool canSelect() {
		return imSelected && Ghetto.instance.open && !Ghetto.instance.full;
	}
}
