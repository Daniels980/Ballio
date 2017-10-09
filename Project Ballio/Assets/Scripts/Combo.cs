using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {

    public string[] Combination;
    public string[] Buttons;
    public string[] Guess;
    private int X;

    void Start()
    {
        X = 0;
    }


    void Update()
    {
        if (X >= 3)
        {
            if (Buttons == Combination)
            {
                Debug.Log("YOU WIN!");
            }
            else
            {
                Debug.Log("YOU LOSE!");
                X = 0;
                Guess[0] = "Blank";
                Guess[1] = "Blank";
                Guess[2] = "Blank";
                Guess[3] = "Blank";
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
