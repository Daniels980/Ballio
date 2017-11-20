using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public GameObject other;
	public int openNo;
	public bool red;
	public bool yellow;
	public bool green;
	private int Rotation;
	private int Rotate_check;
	public GameObject Button;
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate(new Vector3(Rotation, Rotation, 0));
		//openNo set in Unity inspector
		//for red gates (19-22).
		if (red && openNo <= PlayerManager.Get ().stats.Red) //PickupRed
		{
			if (other.gameObject.CompareTag("ToyGate"))
			{
				Rotation = -1;
				Rotate_check += 1;
			}
			else
				other.gameObject.SetActive(false);
		}

		//for yellow gates (19-22).
		if (yellow && openNo <= PlayerManager.Get ().stats.Yellow) //PickupYellow
		{
			if (other.gameObject.CompareTag("ToyGate"))
			{
				Rotation = -1;
				Rotate_check += 1;
			}
			else
				other.gameObject.SetActive(false);
		}

		//for green gates (19-22).
		if (green && openNo <= PlayerManager.Get ().stats.Green) //PickupGreen
		{
			if (other.gameObject.CompareTag("ToyGate"))
			{
				Rotation = -1;
				Rotate_check += 1;
			}
			else
				other.gameObject.SetActive(false);
		}
		if (Rotate_check >= 66)
			Rotation = 0;
	}
}