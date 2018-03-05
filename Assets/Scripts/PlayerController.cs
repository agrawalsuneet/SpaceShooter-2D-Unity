using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed = 10.0f;
	public Boundary boundary;
	public float xTilt = 2.0f;
	public float zTilt = 4.0f;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax )
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (
			GetComponent<Rigidbody>().velocity.z * xTilt, 0.0f, GetComponent<Rigidbody>().velocity.x * -zTilt
		);
	}
}
