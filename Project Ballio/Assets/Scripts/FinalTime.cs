using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTime : MonoBehaviour 
{

	public Text TimeShow;

	void Update ()
	{
		//this shows the final time achieved at the end of the level
        TimeShow.text = "Your final time was: " + Mathf.Floor(PlayerManager.Get().stats.Timer / 60).ToString("0#") + ":" + (PlayerManager.Get().stats.Timer % 60).ToString("0#.00");
    }

}