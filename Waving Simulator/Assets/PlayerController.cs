﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject playerObject;
	float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		playerObject.transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime);
	}
}
