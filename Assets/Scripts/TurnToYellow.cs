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
		Camera cam = Camera.main;
		if (cam == null)
			return;

		if (PointerInput.PrimaryPointerDown()) {
			Vector2 screen = PointerInput.PrimaryScreenPosition();
			Ray ray = PointerInput.ScreenPointToRay(cam, screen);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
			if (hit) {
				if (hit.collider.gameObject == this.gameObject) {
					SpriteRenderer sr = GetComponent<SpriteRenderer>();
					sr.sprite = yellow;
					imSelected = true;

					Ghetto.instance.markJew();
															
				}		
			}
		}

		if (PointerInput.PrimaryPointerUp()) {
			if (canSelect()) {
				Vector2 screen = PointerInput.PrimaryScreenPosition();
				Vector3 vec = PointerInput.ScreenToWorldPointOnPlayPlane(cam, screen);
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
			Vector2 screen = PointerInput.PrimaryScreenPosition();
			Vector3 pos = PointerInput.ScreenToWorldPointOnPlayPlane(cam, screen);
			transform.position = pos;
		} else {
		//	lr.enabled = false;
		}

	}

	bool canSelect() {
		return imSelected && Ghetto.instance.open && !Ghetto.instance.full;
	}
}
