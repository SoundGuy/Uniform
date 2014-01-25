using UnityEngine;
using System.Collections;

public class ChangeSceneOnTIme : MonoBehaviour {
	public float timeToChange;
	public float startTime;
	public string sceneToChange;
	public AudioClip levelClip;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime > timeToChange) {
			AudioSource src =GameObject.Find("Music").GetComponent<AudioSource>();
			src.clip = levelClip;
			src.playOnAwake = true;
			src.loop = true;
			src.Play();
			Application.LoadLevel(sceneToChange);
		}
	}
}
