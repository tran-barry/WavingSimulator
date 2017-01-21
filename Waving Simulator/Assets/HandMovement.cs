using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HandMovement : MonoBehaviour {

public bool move = false;
public int var = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!move)
		{
			transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
			transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime);//(float)-0.5);
			var++;
			if(var%20 == 0)
				move = true;
		}
		else
		{
			transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
			transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime);//(float)0.5);
			var++;
			if(var%20 == 0)
				move = false;
		}
	}
}
