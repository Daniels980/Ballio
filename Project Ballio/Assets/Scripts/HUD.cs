using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	//these are in reference to the text fields on the canvas that will show the strings.
	public Text TxtRed;
	public Text TxtYellow;
	public Text TxtGreen;
	public Text TimeShow;

	public bool TimeFreeze = false;
	void Start ()
	{
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "Level_1.1")
		{
			PlayerManager.Get().stats.Timer = 0;
		}

		if (sceneName == "LevelSelect")
		{
			PlayerManager.Get().stats.TimeFreeze = true;
		}
		else
		{
			PlayerManager.Get().stats.TimeFreeze = false;
		}
	}
	void Update ()
	{
		//this shows the code used to show the timer, it gets the current time and counts upwards.
		if (!PlayerManager.Get().stats.TimeFreeze) 
		{
			PlayerManager.Get().stats.Timer += Time.deltaTime; //time will increase in value by 1 every second.
			TimeShow.text = "Time: " + PlayerManager.Get().stats.Timer;

		}
			
		//Red text updates to show amount of red pickups collected
		TxtRed.text = "Red: " + PlayerManager.Get().stats.Red.ToString();

		//Yellow text updates to show amount of yellow pickups collected
		TxtYellow.text = "Yellow: " + PlayerManager.Get().stats.Yellow.ToString();

		//Green text updates to show amount of green pickups collected
		TxtGreen.text = "Green: " + PlayerManager.Get().stats.Green.ToString();

		Debug.Log(PlayerManager.Get().stats.Timer);
	}

}
