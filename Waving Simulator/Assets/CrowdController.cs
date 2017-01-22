using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour {

	void GenerateNewCrowd() {
		var crowdSize = transform.childCount;
		GameObject child;
		for (int i = 0 ; i < crowdSize ; i++) {
			//child = transform.GetChild(i);
			//child.GenerateNewPerson();
		}
	}

	void GetOtherCrowd() {

		
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
