using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private float points = 0;
    public Text pointsText;

    public void AddPoints(float amount)
    {
        points += amount;
    }

     public void ResetPoints()
    {
        points = 0;
    }

    void Start()
    {
        SetText();
    }

    void FixedUpdate()
    {
        SetText();
    }

    private void SetText()
    {
        pointsText.text = "Points: " + points.ToString();
    }
}