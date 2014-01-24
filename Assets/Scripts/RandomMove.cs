using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	public Vector3 moveDirection;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		ChooseRandomDirection ();
	
	}


	void ChooseRandomDirection() {

		moveDirection =  new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		moveDirection.Normalize ();
	}


	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		controller.Move(moveDirection * moveSpeed *  Time.deltaTime);

	}
}
