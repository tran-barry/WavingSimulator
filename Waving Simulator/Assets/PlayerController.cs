using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	float startPos = 0;
	float endPos = 10;
    private bool gameStarted = false;
    public GameObject startScreenUI;

	GameObject[] crowds;

	int crowdToChange = 0;

	// Use this for initialization
	void Start () {
		startPos = transform.position.z;
		crowds = new GameObject[2];
		crowds[0] = GameObject.Find("Crowd");
		crowds[1] = GameObject.Find("FutureCrowd");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Jump"))
        {
            gameStarted = true;
            startScreenUI.SetActive(false);
        }

        if (gameStarted)
        {
            // Move forward a little
		    transform.Translate(new Vector3(0,0,1) * speed *  Time.deltaTime);

		// If the position is past a specific point, then warp back
		Vector3 position = transform.position;
		var warp = startPos - position.z;
		if (position.z > endPos) {
			transform.Translate(new Vector3(0,0,warp));
			
			
			var otherCrowd = (crowdToChange + 1) % 2;

			Vector3 pos = crowds[crowdToChange].transform.position;
			crowds[crowdToChange].transform.position = crowds[otherCrowd].transform.position;
			crowds[otherCrowd].transform.position = pos;


			var controller = crowds[crowdToChange].GetComponent(typeof(CrowdController)) as CrowdController;
			controller.GenerateNewCrowd();

			crowdToChange = otherCrowd;
		}
	}
}
