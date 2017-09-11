using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public GameObject other;
	public int openNo;
	public bool red;
	public bool yellow;
	public bool green;


	// Update is called once per frame
	void Update () 
	{
		//openNo set in Unity inspector
		//for red gates
		if (red && openNo <= PlayerManager.Get ().stats.Red) 
		{
			other.gameObject.SetActive(false);
		}

		//for yellow gates
		if (yellow && openNo <= PlayerManager.Get ().stats.Yellow) 
		{
			other.gameObject.SetActive(false);
		}

		//for green gates
		if (green && openNo <= PlayerManager.Get ().stats.Green) 
		{
			other.gameObject.SetActive(false);
		}
	}
}
