﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble = 5.0f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;		
	}

}
