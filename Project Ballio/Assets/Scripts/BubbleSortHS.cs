using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleSortHS : MonoBehaviour
{
    public Text[] Scores_T; //Array of Text for inputing the score values, placings, and names into.
    public string[] Places; //string of placings to call in text defining. 1st, 2nd, 3rd, etc.
    public float[] Scores; //Array of score values.
    public string[] Names; //Array of Names that accompany score values.
    private float S_Temp;  //Temporary float for swapping Scores during Bubble Sort.
    private string N_Temp; //Temporary float for swapping Names during Bubble Sort.
    private bool Checked; //Checks if last 'sort through' required any swaps. If not, sorting stops.
    //float PlayerScore = PlayerManager.Get().stats.Timer; //stats.timer freezes then updates on "final score" script. Stores current player's time.

    void Start()
    {
        Scores[11] = PlayerManager.Get().stats.Timer; //player's Score is set as element 11 so that it's included in the bubble sort.
        Names[11] = PlayerManager.Get().stats.PlayerName; //player's Name is set as element 11 so that it's included in the bubble sort.
        Checked = false;
        S_Temp = 0.0f;
        N_Temp = "YYY";
        //for loop for defining text, Public text Scores_T[1] will display '1st: ' plus 'Names[1] ' plus the first place score value in the format of MM:SS.mm.
        for (int j = 10; j >= 1; j--)
        {
            Scores_T[j].text = Places[j] + " " + Names[j] + " " + Mathf.Floor(Scores[j] / 60).ToString("0#") + ":" + (Scores[j] % 60).ToString("0#.00");
        }
        Scores_T[0].text = Places[0] + " " + Names[11] + " " + Mathf.Floor(Scores[11] / 60).ToString("0#") + ":" + (Scores[11] % 60).ToString("0#.00");
    }
    void Update()
    {
        //re-applied every frame to update during bubble sort.
        for (int j = 10; j >= 1; j--)
        {
            Scores_T[j].text = Places[j] + Names[j] + " " + Mathf.Floor(Scores[j] / 60).ToString("0#") + ":" + (Scores[j] % 60).ToString("0#.00");
        }
        /* Bubble sort formatted as a for loop, each Score value in Scores array is compared to the next Score
         * in said array to see if it's shorter. If it is, 'Checked' bool becomes true and both Score values swap
         * places in the array, Names are also swapped to stay paired with their assigned score.
         * 
         * After 2nd is compared to 1st, the value of the 'Checked' bool is checked, if it's set to true then 'i' is set
         * to 11 and 'Checked' bool becomes false again, this causes the for loop to be repeated over and over until all scores
         * are sorted into proper lowest to highest order.
         */
        for (int i = 11; i >= 1; i--)
        {
            if (Scores[i] < Scores[i - 1] && i >= 2)
            {
                Checked = true;
                S_Temp = Scores[i - 1];
                Scores[i - 1] = Scores[i];
                Scores[i] = S_Temp;
                N_Temp = Names[i - 1];
                Names[i - 1] = Names[i];
                Names[i] = N_Temp;
            }
            if (i == 1 && Checked)
            {
                i = 11;
                Checked = false;
            }
        }
    }
}