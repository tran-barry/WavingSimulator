using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.EyeTracking;

public class RaycastGazePoint : MonoBehaviour {
	float _dpi = 1f;//0.5f
	int _hardOffset = 0;//450
	public PointsManager PointsManager;
	public HandMovement HandMovement;

	Vector3Averager _gazeAverager;
	public RaycastGazePoint(){
		_gazeAverager = new Vector3Averager(25);
	}

	// Use this for initialization
	void Start () {
		_gazeAverager = new Vector3Averager(25);
	}
	
	// Update is called once per frame
	void Update () {
		GazePoint gazePoint = EyeTracking.GetGazePoint();
		RaycastHit hit;
		Ray ray;
		if(gazePoint.IsValid)
		{
			_gazeAverager.AddVector(new Vector3(gazePoint.Screen.x * _dpi, gazePoint.Screen.y * _dpi + _hardOffset, 10.0f));
			ray = Camera.main.ScreenPointToRay (_gazeAverager.Average);
		}
		else
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		}
        
		if(Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			//Debug.Log("Hit");
			var lookable = hit.collider.gameObject.GetComponent(typeof(LookableObject));
			if(lookable != null)
				(lookable as LookableObject).LookAt(PointsManager, HandMovement.IsWaving());
		}
	}

	//ENABLE GIZMOS AND SEE A COOL SPHERE
	private void OnDrawGizmos()
	{
		GazePoint gazePoint = EyeTracking.GetGazePoint();
		Vector3	pos;
		if (gazePoint.IsValid)
        {
			_gazeAverager.AddVector(new Vector3(gazePoint.Screen.x * _dpi, gazePoint.Screen.y * _dpi + _hardOffset, 10.0f));
			pos = Camera.main.ScreenToWorldPoint (_gazeAverager.Average);
		}
		else
		{
			pos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));			
		}
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(pos, 0.5f);
	}
}
