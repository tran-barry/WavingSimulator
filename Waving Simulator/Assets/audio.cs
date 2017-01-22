using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audio : MonoBehaviour {

	public AudioSource godSaveTheQueen;
	public AudioSource gunSounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//check the z coordinate
		if(transform.position.z >= 2.8 || transform.position.z < -8){
			//play god save the queen
			//gunSounds.Stop();
			godSaveTheQueen.Play();
			
		}else{
			//play gun shots 
			//godSaveTheQueen.Stop();
			gunSounds.Play();
		}
	}
}
