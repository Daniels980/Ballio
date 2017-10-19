using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {
    public Transform quitMenu;
    public Transform canvas;
    public Button resume;
    public Button exit;

    // Update is called once per frame
    void Update ()
    {
        {
            resume = resume.GetComponent<Button>();
            exit = exit.GetComponent<Button>();
        }
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvas.gameObject.activeInHierarchy == false)
                {
                    canvas.gameObject.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    canvas.gameObject.SetActive(false);
                    Time.timeScale = 1;
                }
            }
        }
		
	}
    public void resumeback()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitPress()
    {
        quitMenu.gameObject.SetActive(true);
        resume.enabled = false;
        exit.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.gameObject.SetActive(false);
        resume.enabled = true;
        exit.enabled = true;
    }
    public void exitout()
    {
        Application.LoadLevel("Start");
    }
}
