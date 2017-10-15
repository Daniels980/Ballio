using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScores : MonoBehaviour {
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
        //"1st: " + Mathf.Floor(PlayerScore / 60).ToString("0#") + ":" + (PlayerScore % 60).ToString("0#.##");

        //Public text S_One will display "1st" plus the score set to the array element 0. Etc for all elements in array.
        S_One.text = "1st: " + Mathf.Floor(Scores[1] / 60).ToString("0#") + ":" + (Scores[1] % 60).ToString("0#.00");
        S_Two.text = "2nd: " + Mathf.Floor(Scores[2] / 60).ToString("0#") + ":" + (Scores[2] % 60).ToString("0#.00");
        S_Three.text = "3rd: " + Mathf.Floor(Scores[3] / 60).ToString("0#") + ":" + (Scores[3] % 60).ToString("0#.00");
        S_Four.text = "4th: " + Mathf.Floor(Scores[4] / 60).ToString("0#") + ":" + (Scores[4] % 60).ToString("0#.00");
        S_Five.text = "5th: " + Mathf.Floor(Scores[5] / 60).ToString("0#") + ":" + (Scores[5] % 60).ToString("0#.00");
        S_Six.text = "6th: " + Mathf.Floor(Scores[6] / 60).ToString("0#") + ":" + (Scores[6] % 60).ToString("0#.00");
        S_Seven.text = "7th: " + Mathf.Floor(Scores[7] / 60).ToString("0#") + ":" + (Scores[7] % 60).ToString("0#.00");
        S_Eight.text = "8th: " + Mathf.Floor(Scores[8] / 60).ToString("0#") + ":" + (Scores[8] % 60).ToString("0#.00");
        S_Nine.text = "9th: " + Mathf.Floor(Scores[9] / 60).ToString("0#") + ":" + (Scores[9] % 60).ToString("0#.00");
        S_Ten.text = "10th: " + Mathf.Floor(Scores[10] / 60).ToString("0#") + ":" + (Scores[10] % 60).ToString("0#.00");
    }
    void Update()
    {
        S_One.text = "1st: " + Mathf.Floor(Scores[1] / 60).ToString("0#") + ":" + (Scores[1] % 60).ToString("0#.00");
        S_Two.text = "2nd: " + Mathf.Floor(Scores[2] / 60).ToString("0#") + ":" + (Scores[2] % 60).ToString("0#.00");
        S_Three.text = "3rd: " + Mathf.Floor(Scores[3] / 60).ToString("0#") + ":" + (Scores[3] % 60).ToString("0#.00");
        S_Four.text = "4th: " + Mathf.Floor(Scores[4] / 60).ToString("0#") + ":" + (Scores[4] % 60).ToString("0#.00");
        S_Five.text = "5th: " + Mathf.Floor(Scores[5] / 60).ToString("0#") + ":" + (Scores[5] % 60).ToString("0#.00");
        S_Six.text = "6th: " + Mathf.Floor(Scores[6] / 60).ToString("0#") + ":" + (Scores[6] % 60).ToString("0#.00");
        S_Seven.text = "7th: " + Mathf.Floor(Scores[7] / 60).ToString("0#") + ":" + (Scores[7] % 60).ToString("0#.00");
        S_Eight.text = "8th: " + Mathf.Floor(Scores[8] / 60).ToString("0#") + ":" + (Scores[8] % 60).ToString("0#.00");
        S_Nine.text = "9th: " + Mathf.Floor(Scores[9] / 60).ToString("0#") + ":" + (Scores[9] % 60).ToString("0#.00");
        S_Ten.text = "10th: " + Mathf.Floor(Scores[10] / 60).ToString("0#") + ":" + (Scores[10] % 60).ToString("0#.00");
        PT.text = "Player Time: " + Mathf.Floor(PlayerScore / 60).ToString("0#") + ":" + (PlayerScore % 60).ToString("0#.00"); //Shows player's current time on canvas.

        //Now we compare the player's current score/time.
        //
        for (int j = 10; j >= 1; j--)
        {
            if (PlayerScore <= Scores[j] && PlayerScore > Scores[j - 1] && !Checked)
            {
                for (int i = 10; i >= j; i--)
                    Scores[i] = Scores[i - 1];
                Scores[j] = PlayerScore;
                Checked = true;
            }
        }
    }
}
