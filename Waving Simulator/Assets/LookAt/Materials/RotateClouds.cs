﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClouds : MonoBehaviour {

	// Use this for initialization

	
	void Start () {


	}
	

	// Update is called once per frame
	void Update () {

			transform.Rotate(4* Time.deltaTime, 4 * Time.deltaTime ,0) ;
		// Move forward a little
	}
}