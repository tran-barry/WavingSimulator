using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClouds : MonoBehaviour {

	// Use this for initialization

	
	void Start () {

		transform.Rotate(Vector3.right * 300 *  Time.deltaTime) ;
	}
	

	// Update is called once per frame
	void Update () {
		// Move forward a little
	}
}
