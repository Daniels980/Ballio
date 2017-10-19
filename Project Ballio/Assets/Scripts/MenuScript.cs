using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
	
	void Start () {

        quitMenu = quitMenu.GetComponent<Canvas>();           //Get the component of the Canvas within the current scene.
        startText = startText.GetComponent<Button>();           
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;


    }
    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }
	
    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }
    public void StartLevel()
    {
        Application.LoadLevel("FinalGameTest");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

	// Update is called once per frame
	void Update () {
		
	}
}
