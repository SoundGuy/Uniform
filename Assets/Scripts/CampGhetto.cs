using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CampGhetto : MonoBehaviour {
	public GameObject jew;
	Ghetto gt;
	public List<GameObject> jewObjects;

	public bool clearing;
	public float lastClearTime;
	public float clearTimeInterval;

	public Train train;

	// Use this for initialization
	void Start () {
		jewObjects = new List<GameObject>();
		clearing=false;
		lastClearTime =0;

		Train [] trains = GameObject.FindObjectsOfType<Train>();
		foreach (Train t in trains) {
			if (t.transform.parent.gameObject == transform.parent.gameObject)
				train = t;
		}

		gt = GetComponent<Ghetto>();
		for (int i=0;i< gt.jewsInGhetto;i++) {
			Vector3 vec = transform.position;
			vec.x += Random.Range(-0.5f,0.5f);
			vec.y += Random.Range(-0.5f,0.5f);

			GameObject obj = (GameObject)Instantiate(jew,vec,Quaternion.identity);
			//obj.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<TurnToYellow>().yellow;
			jewObjects.Add(obj);
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if (gt != null) {
			GetComponent<SpriteRenderer>().sprite = gt.full ? gt.closedSprite : gt.openSprite;
			if (gt.full) {
				if (train.longTrainRunning) 
					train.GetComponent<SpriteRenderer>().enabled = true;
				
			} else {
				if (train.longTrainRunning) {
					train.GetComponent<SpriteRenderer>().enabled = true;
				} else {
					train.GetComponent<SpriteRenderer>().enabled = false;
				}
				      
			}
		}

		Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1") &&  GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(vec.x,vec.y))) {
			clearing = true;
		}

		if (jewObjects.Count == 0) {
			if (clearing) {
				train.GetComponent<SpriteRenderer>().sprite = train.yellowTrain;
				train.RunTrain();
				gt.full = false;
			}
			clearing = false;
		}

		if (clearing && (Time.time - lastClearTime  > clearTimeInterval)) {
			lastClearTime = Time.time;
			// move jew
			train.jews++;
			GameObject obj = jewObjects[0];
			jewObjects.RemoveAt(0);
			Destroy(obj);
		}
		
	}
}
