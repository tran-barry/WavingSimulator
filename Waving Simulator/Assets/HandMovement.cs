using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class HandMovement : MonoBehaviour {

public bool move = false;
public AnimationCurve curve ;
public float var = 0;
	// Use this for initialization
	void Start () {
		curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 30));
		curve.preWrapMode = WrapMode.PingPong;
		curve.postWrapMode = WrapMode.PingPong;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			transform.eulerAngles = new Vector3(90, 190, curve.Evaluate(var));
			var += (float)0.5*Time.deltaTime;
		}
		/*if(!move)
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
		}*/
	}
}
