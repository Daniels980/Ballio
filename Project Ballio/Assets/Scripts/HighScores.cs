using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    public Text PT; // Player's current score.
    public Text S_Ten; //Score Ten.
    public Text S_Nine; //Score Nine, etc.
    public Text S_Eight;
    public Text S_Seven;
    public Text S_Six;
    public Text S_Five;
    public Text S_Four;
    public Text S_Three;
    public Text S_Two;
    public Text S_One;

    public float[] Scores; //Array of scores.
    private bool Checked; //inputs player's score once into list, otherwise fires forever.
    float PlayerScore = PlayerManager.Get().stats.Timer; //stats.timer freezes then updates on "final score" script. Stores current player's time.

    void Start()
    {
        Checked = false;

        S_One.text = "1st: " + Scores[0]; //Public text S_One will display "1st" plus the score set to the array element 0. Etc for all elements in array.
        S_Two.text = "2nd: " + Scores[1];
        S_Three.text = "3rd: " + Scores[2];
        S_Four.text = "4th: " + Scores[3];
        S_Five.text = "5th: " + Scores[4];
        S_Six.text = "6th: " + Scores[5];
        S_Seven.text = "7th: " + Scores[6];
        S_Eight.text = "8th: " + Scores[7];
        S_Nine.text = "9th: " + Scores[8];
        S_Ten.text = "10th: " + Scores[9];
    }
    void Update()
    {
        S_One.text = "1st: " + Scores[0];
        S_Two.text = "2nd: " + Scores[1];
        S_Three.text = "3rd: " + Scores[2];
        S_Four.text = "4th: " + Scores[3];
        S_Five.text = "5th: " + Scores[4];
        S_Six.text = "6th: " + Scores[5];
        S_Seven.text = "7th: " + Scores[6];
        S_Eight.text = "8th: " + Scores[7];
        S_Nine.text = "9th: " + Scores[8];
        S_Ten.text = "10th: " + Scores[9];

        PT.text = "Player Time: " + PlayerScore; //Shows player's current time on canvas.

        //Now we compare the player's current score/time.
        if (PlayerScore <= Scores[9] && PlayerScore > Scores[8] && !Checked) // if the current player time is less than 10th (element 9) and more than 9th, and hasnt been compared already. Set 10th to player's current score/time.
        {
            Scores[9] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[8] && PlayerScore > Scores[7])
        {
            Scores[9] = Scores[8]; //when current player time is faster than 9th, set existing 9th to 10th.
            Scores[8] = PlayerScore; //Now that 9th has been moved, set 9th to Player's time.
            Checked = true;
        }
        if (PlayerScore <= Scores[7] && PlayerScore > Scores[6] && !Checked)
        {
            for (int i = 9; i >= 8; i--) // i = 9, check if i is greater than 8, minus 1 from i, run loop until not true.
            {
                Scores[i] = Scores[i - 1]; //"Scores" array element "i" equals the element below "i" similar to saying Scores[9] = Scores[8] as above.
            }
            Scores[7] = PlayerScore; //Once scores have been moved from 8th to 9th, 9th to 10th and 10th saved over. Save player's current time as 7th.
            Checked = true;
        }
        if (PlayerScore <= Scores[6] && PlayerScore > Scores[5] && !Checked)
        {
            for (int i = 9; i >= 7; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[6] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[5] && PlayerScore > Scores[4] && !Checked)
        {
            for (int i = 9; i >= 6; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[5] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[4] && PlayerScore > Scores[3] && !Checked)
        {
            for (int i = 9; i >= 5; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[4] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[3] && PlayerScore > Scores[2] && !Checked)
        {
            for (int i = 9; i >= 4; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[3] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[2] && PlayerScore > Scores[1] && !Checked)
        {
            for (int i = 9; i >= 3; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[2] = PlayerScore;
            Checked = true;
        }
        if (PlayerScore <= Scores[1] && PlayerScore > Scores[0] && !Checked)
        {
            for (int i = 9; i >= 2; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[1] = PlayerScore;
            Checked = true;
        }
        else if (PlayerScore <= Scores[0] && !Checked)
        {
            for (int i = 9; i >= 1; i--)
            {
                Scores[i] = Scores[i - 1];
            }
            Scores[0] = PlayerScore;
            Checked = true;
        }

        Debug.Log(PlayerManager.Get().stats.Timer);
    }
}