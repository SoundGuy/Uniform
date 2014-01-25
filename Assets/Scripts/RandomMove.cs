using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

	//public Vector3 moveDirection;
	public float moveSpeed;
	public float bounceSpeed;

	public float velo;

	public ContactPoint2D [] lastcontacts;

	// Use this for initialization
	void Start () {
		ChooseRandomDirection ();
		rigidbody2D.AddForce(moveSpeed * transform.up);
	
	}

	void OnDrawGizmos()  {
		if (lastcontacts == null)
				return;
		foreach (ContactPoint2D pnt in lastcontacts) {
			Debug.DrawRay(pnt.point,pnt.normal * 2f);
				}
	}

	void ChooseRandomDirection() {

		//moveDirection =  new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f), 0);
		//moveDirection.Normalize ();
		transform.Rotate (0, 0, Random.Range (0, 360f));
	}



	void OnCollisionEnter2D(Collision2D collision) {
		//transform.Rotate (0, 0, Random.Range (0, 180f));

		//Debug.Log ("Collided Rigidbody" + collision.collider.name);
		lastcontacts = collision.contacts;
		foreach (ContactPoint2D c in collision.contacts) {
			if (c.collider.gameObject.name == "CageWall") {
				//Debug.Log("HitWall!!");
			 	rigidbody2D.velocity = (bounceSpeed * c.normal );
				ChooseRandomDirection();
			}
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
	void FixedUpdate () {
		/*
		if (rigidbody2D.velocity.sqrMagnitude < 0.3f) {
			//ChooseRandomDirection();
			rigidbody2D.velocity = (moveSpeed * transform.up);
		}*/

		//if (rigidbody2D.velocity.sqrMagnitude > 2f) 
			rigidbody2D.velocity = moveSpeed * rigidbody2D.velocity.normalized;

		velo = rigidbody2D.velocity.sqrMagnitude;





	}


	public  IEnumerator Choke() {
		yield return new WaitForSeconds(Random.Range(0f,2f));
	}

	public IEnumerator Kill() {
		moveSpeed = moveSpeed /10f;
		//yield return new WaitForSeconds(Random.Range(0f,2f));
		yield return new WaitForSeconds(Random.Range(2f,7f));
		Destroy(this.gameObject);
	}

}

