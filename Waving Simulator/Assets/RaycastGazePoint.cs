using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RaycastGazePoint : MonoBehaviour {
	float dpi = 0.5f;//0.5f
	int hardOffset = 450;//450
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GazePoint gazePoint = EyeTracking.GetGazePoint();
		RaycastHit hit;
		Ray ray;
		if(gazePoint.IsValid)
		{
			ray = Camera.main.ScreenPointToRay (new Vector3(gazePoint.Screen.x * dpi, gazePoint.Screen.y * dpi + hardOffset, 10.0f));	
		}
		else
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		}
        
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Debug.Log("Hit");
		}
	}

	//ENABLE GIZMOS AND SEE A COOL SPHERE
	private void OnDrawGizmos()
	{
		GazePoint gazePoint = EyeTracking.GetGazePoint();
		Vector3	pos;
		if (gazePoint.IsValid)
        {
			pos = Camera.main.ScreenToWorldPoint (new Vector3(gazePoint.Screen.x * dpi, gazePoint.Screen.y * dpi + hardOffset, 10.0f));
		}
		else
		{
			pos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));			
		}
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(pos, 0.5f);
	}
}
