using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour 
{

    //this script is used on the start menu and game over menu. Using buttons and build settings you can seemlessly transition from scene to scene with this type of code.

    public Canvas quitMenu;         //Holds the quit canvas.
    public Button startText;        //Holds the Start button
    public Button exitText;         //Holds the Exit button

    private void Start()    //Disables the Quit menu image and the child linked underneath it.
    {
        quitMenu.enabled = false;
    }

    //loads the scene containing the gameplay when the applied button is clicked on. This is done by using the SceneManager class (13-16).
    public void OnNewGame_Clicked() //ButtonNG
    {
		SceneManager.LoadScene("LevelSelect"); 
	}

	//loads the start menu scene when you press the main menu button in the Win scene. This is also done by using the SceneManager class (19-22).
	public void OnMenu_Clicked()    //ButtonMenu
    {
		SceneManager.LoadScene ("StartMenu");
	}

	//Exits the game by using the Application class (26-28).
	public void OnExit_Clicked() //Opens quit menu and disactivate Game start and exit button
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPress()  //Redirect back to main menu and re actives game start and exit button
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void YesPress()  //Exit Application
    {
        Application.Quit();
    }

    public void OnOneOne_Clicked() //Loads and starts level 1 world 1 :D
	{
		SceneManager.LoadScene("Level_1.1");
	}

	public void OnOneTwo_Clicked() //Loads and starts level 2 world 1 :D
	{
		SceneManager.LoadScene("Level_1.2");
	}

	public void OnOneThree_Clicked() //Loads and starts level 3 world 1 A bit tougher now!
	{
		SceneManager.LoadScene("Level_1.3");
	}
		
	public void OnTwoOne_Clicked() //Loads and starts level 1 world 2 Time to charge!
	{
		SceneManager.LoadScene("Level_2.1");
	}

	public void OnTwoTwo_Clicked() //Loads and starts level 2 world 2 Time to charge, again!
	{
		SceneManager.LoadScene("Level_2.2");
	}

	public void OnTwoThree_Clicked() //Loads and starts level 3 world 2 Time to charge, again! and again!
	{
		SceneManager.LoadScene("Level_2.3");
	}

	public void OnThreeOne_Clicked() //Loads and starts level 1 world 3 Let's get disco dancin'
	{
		SceneManager.LoadScene("Level_3.1");
	}
		
	public void OnThreeTwo_Clicked() //Loads and starts level 2 world 3 Let's get disco dancin'
	{
		SceneManager.LoadScene("Level_3.2");
	}

	public void OnThreeThree_Clicked() //Loads and starts level 3 world 3 Are you the disco master?
	{
		SceneManager.LoadScene("Level_3.3");
	}

	public void OnFourOne_Clicked() //Loads and starts level 1 world 4 penthouse please!
	{
		SceneManager.LoadScene("Level_4.1");
	}

	public void OnFourTwo_Clicked() //Loads and starts level 2 world 4 penthouse please!
	{
		SceneManager.LoadScene("Level_4.2");
	}

	public void OnFourThree_Clicked() //Loads and starts level 3 world 4 Can you RISE to the occasion?
	{
		SceneManager.LoadScene("Level_4.3");
	}
}