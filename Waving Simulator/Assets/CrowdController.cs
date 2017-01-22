using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdController : MonoBehaviour {

	public void GenerateNewCrowd() {
		foreach(Transform child in transform) {
			LookableObject person = child.GetComponent(typeof(LookableObject)) as LookableObject;
			person.GenerateNewPerson();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
