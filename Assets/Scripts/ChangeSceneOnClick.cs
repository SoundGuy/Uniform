using UnityEngine;
using System.Collections;

public class ChangeSceneOnClick : MonoBehaviour {
	public AudioClip levelClip;
	public string scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			if (levelClip != null) {
				AudioSource src =GameObject.Find("Music").GetComponent<AudioSource>();
				src.clip = levelClip;
				src.playOnAwake = true;
				src.loop = true;
				src.Play();
			}
			Application.LoadLevel(scene);
		}
	}
}
