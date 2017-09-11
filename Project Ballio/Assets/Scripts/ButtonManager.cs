using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{

	//this is used on the start menu and game over menu. Using buttons and build settings you can seemlessly transition from scene to scene with this type of code.

	//loads the scene containing the gameplay when the applied button is clicked on.
	public void OnNewGame_Clicked()
	{
		SceneManager.LoadScene("MiniGame");
	}

	//loads the start menu scene when you press the main menu button in the Win scene.
	public void OnMenu_Clicked()
	{
		SceneManager.LoadScene ("StartMenu");
	}

	//Exits the game
	public void OnExit_Clicked()
	{
		Application.Quit ();
	}
}
