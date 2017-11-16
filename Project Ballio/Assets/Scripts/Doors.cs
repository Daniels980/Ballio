﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public GameObject other;
	public int openNo;
	public bool red;
	public bool yellow;
	public bool green;
	public int Rotation;

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(0, Rotation, 0));
		//openNo set in Unity inspector
		//for red gates (19-22).
		if (red && openNo <= PlayerManager.Get ().stats.Red) //PickupRed
		{
				other.gameObject.SetActive(false);
		}

		//for yellow gates (19-22).
		if (yellow && openNo <= PlayerManager.Get ().stats.Yellow) //PickupYellow
		{
				other.gameObject.SetActive(false);
		}

		//for green gates (19-22).
		if (green && openNo <= PlayerManager.Get ().stats.Green) //PickupGreen
		{
				other.gameObject.SetActive(false);
		}
		if (Rotation >= 90)
			Rotation = 90;
	}
}