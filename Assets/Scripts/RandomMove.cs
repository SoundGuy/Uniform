using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	//public Vector3 moveDirection;
	public float moveSpeed;
	public float bounceSpeed;

	// Use this for initialization
	void Start () {
		ChooseRandomDirection ();
		rigidbody2D.AddForce(moveSpeed * transform.up);
	
	}


	void ChooseRandomDirection() {

		//moveDirection =  new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		//moveDirection.Normalize ();
		transform.Rotate (0, 0, Random.Range (0, 360f));
	}



	void OnCollisionEnter2D(Collision2D collision) {
		//transform.Rotate (0, 0, Random.Range (0, 180f));

		//Debug.Log ("Collided Rigidbody" + collision.collider.name);
		foreach (ContactPoint2D c in collision.contacts) {
			rigidbody2D.AddForce(bounceSpeed * c.normal );
		}
	}

	//void OnControllerColliderHit(ControllerColliderHit hit) {
	//	Vector3 moveDirection;
	//	transform.Rotate (0, 0, 180f);
	//	Debug.Log ("COllided");
		/*
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;*/
	//}

	// Update is called once per frame
	void Update () {

		if (rigidbody2D.velocity.sqrMagnitude < 0.3f) 
			rigidbody2D.AddForce(moveSpeed * transform.up);

		//CharacterController controller = GetComponent<CharacterController> ();
		//controller.Move(transform.up * moveSpeed *  Time.deltaTime);





	}
	
}

