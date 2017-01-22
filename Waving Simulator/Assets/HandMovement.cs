using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HandMovement : MonoBehaviour {
public bool move = false;
public AnimationCurve curve ;
public float var = 0;

public GameObject cube;

public float stamina = 300;
private float fontSize;
private Color color;
public Color colorNeutral = Color.green;
public float fontSizeNormal = 16;
public Text staminaText;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 30));
		curve.preWrapMode = WrapMode.PingPong;
		curve.postWrapMode = WrapMode.PingPong;
		SetText();
		stamina = 300;
        fontSize = 16;
        color = colorNeutral;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && stamina > 0)
		{
			if(transform.eulerAngles.x > 0 && transform.eulerAngles.x < 100)
			{
				cube.transform.Rotate(-75*Time.deltaTime, 0, 0);
			}
			else
			{
				cube.transform.eulerAngles = new Vector3(0, curve.Evaluate(var), 0);
				var += (float)1.5 * Time.deltaTime;
			}

		}
		else if((!Input.GetMouseButton(0) || stamina <= 0) && transform.eulerAngles.x < 85)
		{
			cube.transform.Rotate(75*Time.deltaTime, 0, 0);
		}
		if(stamina > 0 && Input.GetMouseButton(0))
		{
			stamina -= 30 * Time.deltaTime;
			if(stamina < 0)
				stamina = 0;
		}
		if(stamina < 300 && !Input.GetMouseButton(0))
		{
			stamina += 30 * Time.deltaTime;
			if(stamina > 300)
				stamina = 300;
		}
		SetText();
	}
	private void SetText()
    {
		int s = (int)stamina;
		staminaText.text = "Stamina: " + s.ToString();
        staminaText.fontSize = (int)fontSize;
        staminaText.color = color;
    }

	public bool isWaving()
	{
		if(Input.GetMouseButton(0) && stamina > 0)
		{
			return true;
		}
		return false;
	}
}
