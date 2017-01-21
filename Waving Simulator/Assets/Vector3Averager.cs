using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Averager : MonoBehaviour {
	private int _count = 0;
	private int _vectorsAveraged;
	private Vector3[] _vectorArray;

	public Vector3Averager(int vectors)
	{
		_vectorsAveraged = vectors;
		_vectorArray = new Vector3[vectors];
		for(int i = 0; i < _vectorsAveraged; ++i){
			_vectorArray[i] = new Vector3(0, 0, 0);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddVector(Vector3 vector)
	{
		int index = _count % _vectorsAveraged;
		_vectorArray[index] = vector;
		++_count;
	}

	public Vector3 Average
	{
		get
		{
			float x = 0;
			float y = 0;
			float z = 0;
			for(int i = 0; i < _vectorsAveraged; ++i)
			{
				x += _vectorArray[i].x / _vectorsAveraged;
				y += _vectorArray[i].y / _vectorsAveraged;
				z += _vectorArray[i].z / _vectorsAveraged;
			}

			return new Vector3(x, y, z);
		}
	}
}
