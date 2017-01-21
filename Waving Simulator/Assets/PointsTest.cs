using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTest : MonoBehaviour
{
    public PointsManager pointsManager;

    // Update is called once per frame
    void Update()
    {
        pointsManager.AddPoints(transform.position.z);
    }
}