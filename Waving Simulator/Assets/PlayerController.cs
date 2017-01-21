using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class PlayerController : MonoBehaviour {
	float speed = 1;
	float startPos = 0;
	float endPos = 10;

	// Use this for initialization
	void Start () {
		startPos = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		// Move forward a little
		transform.Translate(new Vector3(0,0,1) * speed *  Time.deltaTime);

		// If the position is past a specific point, then warp back
		Vector3 position = transform.position;
		var warp = startPos - position.z;
		if (position.z > endPos) {
			transform.Translate(new Vector3(0,0,warp));
		}
	}
}
