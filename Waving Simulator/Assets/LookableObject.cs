using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObject : MonoBehaviour {

	//Public variables
	private PointsManager _pointsManager;
	public List<PersonInfo> Persons;
	private float currentHealth;
	private bool isLookedAt = false;
	private bool isAlive  { get { return currentHealth > 0; } }
	private int ID;
	private float healthDecreaseAmount = 1000;

	//Call when looking at this object. It will do its thing in Update
	public void LookAt(PointsManager manager)
	{
		_pointsManager = manager;
		isLookedAt = true;
	}
	
	// Call this to make it generate a new one
	public void New() {
		ID = (int)(Random.value * Persons.Count);

		GetComponent<Renderer>().material = Persons[ID].Material;
		currentHealth = Persons[ID].Health;
	}

	public float GetHealth()
	{
		return currentHealth;
	}

	private void Start()
	{
		New();
	}

	// Update is called once per frame
	void LateUpdate () {
		if (isLookedAt)// && isAlive)
		{
			// currentHealth -= healthDecreaseAmount * Time.deltaTime;

			// if (currentHealth <= 0.0f)
				_pointsManager.AddPoints(Persons[ID].Reward);
				
		}
		isLookedAt = false;
	}
}
