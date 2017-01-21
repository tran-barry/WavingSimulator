using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class HandMovement : MonoBehaviour {

public bool move = false;
public AnimationCurve curve ;
public float var = 0;
public float stamina = 100;
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
			if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 100)
			{
				transform.Rotate(-30*Time.deltaTime, 0, 0);
			}
			else
			{
				transform.eulerAngles = new Vector3(0, curve.Evaluate(var), 0);
				var += (float)0.5 * Time.deltaTime;
			}

		}
		else if(!Input.GetMouseButton(0) && transform.eulerAngles.x < 75)
		{
			transform.Rotate(30*Time.deltaTime, 0, 0);
			//Debug.Log(transform.eulerAngles.x);
		}
	}
}
