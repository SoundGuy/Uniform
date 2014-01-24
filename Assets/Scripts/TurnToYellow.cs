using UnityEngine;
using System.Collections;

public class TurnToYellow : MonoBehaviour {

	public Sprite yellow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log("Fire1");

			// PC
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
				if (hit) {
					Debug.Log("Ray" + hit.collider.name);
					if (hit.collider.gameObject == this.gameObject) {
						Debug.Log("Hit!" + hit);
						SpriteRenderer sr = GetComponent<SpriteRenderer>();
						sr.sprite = yellow;
										
				}
		
			}
		}

	}
}
