using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsTest : MonoBehaviour
{
    public PointsManager pointsManager;
    private int frames = 0;
    // Update is called once per frame
    void Update()
    {
        if (frames == 0)
        {
              pointsManager.AddPoints(transform.position.z);
        }
        frames = (frames + 1) % 60;
    }
}