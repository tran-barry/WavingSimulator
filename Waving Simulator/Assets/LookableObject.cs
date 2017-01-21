using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookableObject : MonoBehaviour {

    //Public variables
    public float pointsEarned = 10.0f;
    public float startingHealth = 100.0f;
    public float healthDecreaseAmount = 5.0f;//Multiplied by dtime
    public PointsManager pointsManager;
    
    private float health;
    private bool isLookedAt = false;
    private bool isAlive = true;

    //Call when looking at this object. It will do its thing in Update
    public void LookAt()
    {
        isLookedAt = true;
    }
	
    public float GetHealth()
    {
        return health;
    }

    private void Start()
    {
        health = startingHealth;
    }

    // Update is called once per frame
    void Update () {
		if (isLookedAt && isAlive)
        {
            health -= healthDecreaseAmount * Time.deltaTime;

            if (health <= 0.0f)
            {
                pointsManager.AddPoints(pointsEarned);
                isAlive = false;
            }
        }
        isLookedAt = false;
	}
}
