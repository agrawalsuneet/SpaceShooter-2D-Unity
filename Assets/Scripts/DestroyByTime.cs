﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float lifetime = 2.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	}
}
