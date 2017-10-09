using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combo : MonoBehaviour {

    public string[] Combination;
    public string[] Buttons;
    public string[] Guess;
    private int X;

    public GameObject Door;

    public string Scene;

    void Start()
    {
        X = 0;
    }


    void Update()
    {
        if (X >= 4)
        {
            if (Guess[0] == "B" && Guess[1] == "G" && Guess[2] == "Y" && Guess[3] == "R")
            {
                Debug.LogWarning("YOU WIN!");
                Door.SetActive(false);
            }
            else
            {
                Debug.LogWarning("YOU LOSE!");
                SceneManager.LoadScene(Scene);
            }
        }
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("B_Red"))
        {
            Guess[X] = Buttons[0];
            X = X + 1;
        }
        if (Other.gameObject.CompareTag("B_Blue"))
        {
            Guess[X] = Buttons[1];
            X = X + 1;
        }
        if (Other.gameObject.CompareTag("B_Yellow"))
        {
            Guess[X] = Buttons[2];
            X = X + 1;
        }
        if (Other.gameObject.CompareTag("B_Green"))
        {
            Guess[X] = Buttons[3];
            X = X + 1;
        }
    }
}
