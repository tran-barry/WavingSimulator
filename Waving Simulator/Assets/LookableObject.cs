using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObject : MonoBehaviour {

	//Public variables
	private PointsManager _pointsManager;
	public List<PersonInfo> Persons;
	public PointsManager pointsManager;
    public float scaleFactor = 0.1f;
    public float sinFreq = 1.0f;

	private float currentHealth;
	private bool isLookedAt = false;
	private bool isAlive  { get { return currentHealth > 0; } }
	private int ID;
	private float healthDecreaseAmount = 1000;
    private float timeFirstLookedAt = -1.0f;
    private Vector3 startScale;

	//Call when looking at this object. It will do its thing in Update
	public void LookAt(PointsManager manager)
	{
		_pointsManager = manager;
		isLookedAt = true;

        if (timeFirstLookedAt < 0.0f)
        {
            timeFirstLookedAt = Time.time;
        }
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
		startScale = transform.localScale;

		ID = (int)(Random.value * Persons.Count);

		GetComponent<Renderer>().material = Persons[ID].Material;
		currentHealth = Persons[ID].Health;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (isLookedAt)// && isAlive)
		{
			// currentHealth -= healthDecreaseAmount * Time.deltaTime;

			if (currentHealth <= 0.0f)
				pointsManager.AddPoints(Persons[ID].Reward);

		}
        else
        {
            timeFirstLookedAt = -1.0f;
        }

        Pulsate();

       	isLookedAt = false;
	}

    private void Pulsate()
    {
        if (isLookedAt)
        {
            //sin wave pulsate the size
            transform.localScale = Vector3.one * (1.0f + scaleFactor * Mathf.Sin(sinFreq * (timeFirstLookedAt - Time.time)));
        }
        else
        {
            //Linearly interpolate back to starting scale
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Lerp(transform.localScale.x, startScale.x, 1.0f * Time.deltaTime);
            localScale.y = Mathf.Lerp(transform.localScale.y, startScale.y, 1.0f * Time.deltaTime);
            localScale.z = Mathf.Lerp(transform.localScale.z, startScale.z, 1.0f * Time.deltaTime);
            transform.localScale = localScale;
        }
    }
}
