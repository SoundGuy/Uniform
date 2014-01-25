using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CampGhetto : MonoBehaviour {
	public GameObject jew;
	public GameObject jewGray;
	Ghetto gt;
	public List<GameObject> jewObjects;


	public bool clearing;
	public float lastClearTime;
	public float clearTimeInterval;

	public Train train;

	public int campGhettoIdx;

	public UILabel scoreLabel;
	public UILabel scoreLabel1;
	public float scoreLerp;

	// Use this for initialization
	void Start () {

		Train [] trains = GameObject.FindObjectsOfType<Train>();
		foreach (Train t in trains) {
			if (t.transform.parent.gameObject == transform.parent.gameObject) {
				train = t;
				t.ghetto = this;
			}
		}

		scoreLabel = GameObject.Find("Score").GetComponent<UILabel>();
		scoreLabel1 = GameObject.Find("ScoreLabel").GetComponent<UILabel>();


	
	}

	public void initJews() {
		jewObjects = new List<GameObject>();
		clearing=false;
		lastClearTime =0;

		gt = GetComponent<Ghetto>();
		for (int i=0;i<10;i++) {
			Vector3 vec = transform.position;
			vec.x += Random.Range(-0.5f,0.5f);
			vec.y += Random.Range(-0.5f,0.5f);
			
			GameObject obj = (GameObject)Instantiate(i< gt.jewsInGhetto ? jew : jewGray,vec,Quaternion.identity);
			//obj.GetComponent<SpriteRenderer>().sprite = obj.GetComponent<TurnToYellow>().yellow;
			jewObjects.Add(obj);
			//Debug.Log("jews in campGhetto " + campGhettoIdx + "  = " + jewObjects.Count);
		}
	}

	// Update is called once per frame
	void Update () {
		if (gt != null) {
			GetComponent<SpriteRenderer>().sprite = gt.full ? gt.closedSprite : gt.openSprite;
			train.GetComponent<SpriteRenderer>().enabled = gt.full || train.longTrainRunning;				
			/*if (gt.full) {

				if (train.longTrainRunning) 
					train.GetComponent<SpriteRenderer>().enabled = true;				
			} else {
				if (train.longTrainRunning) {
					train.GetComponent<SpriteRenderer>().enabled = true;
				} else {
					train.GetComponent<SpriteRenderer>().enabled = false;
				}

			}*/
			
			Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetButtonDown("Fire1") &&  GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(vec.x,vec.y))) {
				foreach(GameObject jewObj in jewObjects) {
					jewObj.GetComponent<SpriteRenderer>().sprite = jew.GetComponent<SpriteRenderer>().sprite;
					gt.full = true;
					gt.jewsInGhetto = 10;
				}
			}
			
			if (jewObjects.Count == 0) {
				if (clearing) {
					train.GetComponent<SpriteRenderer>().sprite = train.yellowTrain;
					train.RunTrain();
					gt.full = false;
				}
				clearing = false;
			}
		}


		if (clearing && (Time.time - lastClearTime  > clearTimeInterval)) {
			lastClearTime = Time.time;
			// move jew
			train.jews++;
			GameObject obj = jewObjects[0];
			jewObjects.RemoveAt(0);
			Destroy(obj);
		}

		if (GameState.instance) {
			scoreLerp = Mathf.Lerp(scoreLerp,GameState.instance.Score,Time.deltaTime);
			scoreLabel.text = ((int)scoreLerp).ToString("#,#");

			scoreLabel.enabled = GameState.instance.Score > 0;
			scoreLabel1.enabled = GameState.instance.Score > 0;


			if (scoreLerp > 6000000) {
				StartCoroutine(endGame());
			}
		}

	}

	IEnumerator endGame() {
		yield return new WaitForSeconds(9f);
		GameObject.Find("Music").GetComponent<AudioSource>().Stop();
		Application.LoadLevel("FinalSolution");
	}
}
