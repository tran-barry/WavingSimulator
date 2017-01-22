using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    private static PointsManager _instance;
    private PointsManager(){

    }

    public static PointsManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public Text pointsText;
    public float fontSizeBad = 22;
    public float fontSizeNormal = 16;
    public float fontSizeGood = 18;
    public float lerpFactor = 2.0f;
    public Color colorGood = Color.green;
    public Color colorNeutral = Color.white;
    public Color colorBad = Color.red;

    private float points = 0;
    private Color color;
    private float fontSize;

    public void AddPoints(float amount)
    {
        points += amount;
        points = Mathf.Min(0, points);

        if (amount < 0)
        {
            color = colorBad;
            fontSize = fontSizeBad;
        }
        else if (amount > 0)
        {
            color = colorGood;
            fontSize = fontSizeGood;
        }
    }

    public void ResetPoints()
    {
        points = 0;
    }

    void Start()
    {
        _instance = new PointsManager();
        SetText();
        fontSize = fontSizeNormal;
        color = colorNeutral;
    }

    void FixedUpdate()
    {
        SetText();
        
        fontSize = Mathf.Lerp(fontSize, fontSizeNormal, lerpFactor * Time.deltaTime);

        color.r = Mathf.Lerp(color.r, colorNeutral.r, lerpFactor * Time.deltaTime);
        color.g = Mathf.Lerp(color.g, colorNeutral.g, lerpFactor * Time.deltaTime);
        color.b = Mathf.Lerp(color.b, colorNeutral.b, lerpFactor * Time.deltaTime);
    }

    private void SetText()
    {
        pointsText.text = "Points: " + points.ToString();
        pointsText.fontSize = (int)fontSize;
        pointsText.color = color;
    }
}