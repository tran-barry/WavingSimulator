using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text pointsText;
    public float fontBadSize = 12;
    public float fontSizeNormal = 14;
    public float fontSizeGood = 16;
    public float colorFadePerFrame = 0.05;

    private float points = 0;
    private Color color = Color.white;
    private float fontSize;

    public void AddPoints(float amount)
    {
        points += amount;
        points = Mathf.min(0, points);

        if (amount < 0)
        {
            color = Color.red;
            fontSize = fontSizeBad;
        }
        else if (ammount > 0)
        {
            color = Color.green;
            fontSize = fontSizeGood;
        }
    }

    public void ResetPoints()
    {
        points = 0;
    }

    void Start()
    {
        SetText();
        fontSize = fontSizeNormal;
    }

    void FixedUpdate()
    {
        SetText();
        
        fontSize =

        color.r = Mathf.Max(color.r + colorFadePerFrame, 1.0f);
        color.g = Mathf.Max(color.g + colorFadePerFrame, 1.0f);
        color.b = Mathf.Max(color.b + colorFadePerFrame, 1.0f);
    }

    private void SetText()
    {
        pointsText.text = "Points: " + points.ToString();
        pointsText.fontSize = fontSize;
        pointsText.color = color;
    }
}