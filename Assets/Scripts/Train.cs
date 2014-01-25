using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {
	public Sprite yellowTrain;
	public Sprite grayTrain;
	public int jews;
	public GameObject jewPF;
	float lastUnloadTime;
	public float unloadTimeDelta = 0.2f;
	public bool unloading;
	public float offloadOffset = -1f;
	public CampGhetto ghetto;

	public bool longTrainRunning;

	// Use this for initialization
	void Start () {
		unloading = false;
		longTrainRunning=false;
		if (animation) {
			Debug.Log("Playing auto = " + animation.playAutomatically);
			animation.playAutomatically = false;
		}

		Animator a = GetComponent<Animator>();
		if (a) {
			a.SetBool("isIdle",true);			
			//a.Play(
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetButtonDown("Fire1") &&  GetComponent<BoxCollider2D>().OverlapPoint(new Vector2(vec1.x,vec1.y))) {
			GetComponent<SpriteRenderer>().sprite = yellowTrain;
			ghetto.clearing = true;
		}

		if (unloading) {
			if (jews>0  && (Time.time - lastUnloadTime) > unloadTimeDelta) {
				lastUnloadTime = Time.time;
				Vector3 vec = Camp.instance.showerHandle.transform.position;
				vec.y += offloadOffset;
				GameObject jewAddedObj = (GameObject) Instantiate(jewPF,vec,Quaternion.identity);
				GameObject.Find("Camp").GetComponent<Camp>().jewsInCamp.Add(jewAddedObj);
				jews--;						
			}

			if (jews == 0) {
				unloading = false;
				GetComponent<SpriteRenderer>().sprite = grayTrain;
				GameObject.Find("Camp").GetComponent<Camp>().TrainUnloaded();
			}


		}
	
	}

	public void RunTrain() {
		GetComponent<Animator>().SetBool("isIdle",false);
		longTrainRunning= true;

	}

	public void UnLoadTrain() {
		unloading=true;


	}

}
