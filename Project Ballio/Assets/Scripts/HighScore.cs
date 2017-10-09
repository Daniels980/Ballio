using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour {

    public Text PT;
    public Text S_Ten;
    public Text S_Nine;
    public Text S_Eight;
    public Text S_Seven;
    public Text S_Six;
    public Text S_Five;
    public Text S_Four;
    public Text S_Three;
    public Text S_Two;
    public Text S_One;

    public float FT;
    public float sONE;
    public float sTWO;
    public float sTHREE;
    public float sFOUR;
    public float sFIVE;
    public float sSIX;
    public float sSEVEN;
    public float sEIGHT;
    public float sNINE;
    public float sTEN;

    void Start()
    {
        S_One.text = "1st: " + sONE;
        S_Two.text = "2nd: " + sTWO;
        S_Three.text = "3rd: " + sTHREE;
        S_Four.text = "4th: " + sFOUR;
        S_Five.text = "5th: " + sFIVE;
        S_Six.text = "6th: " + sSIX;
        S_Seven.text = "7th: " + sSEVEN;
        S_Eight.text = "8th: " + sEIGHT;
        S_Nine.text = "9th: " + sNINE;
        S_Ten.text = "10th: " + sTEN;
    }
    void Update()
    {
        PT.text = "Player Time: " + (PlayerManager.Get().stats.Timer + FT);

        if ((PlayerManager.Get().stats.Timer + FT) <= sTEN && (PlayerManager.Get().stats.Timer + FT) > sNINE)
        {
            S_Ten.text = "10th: " + (PlayerManager.Get().stats.Timer + FT);
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sNINE && (PlayerManager.Get().stats.Timer + FT) > sEIGHT)
        {
            S_Nine.text = "9th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Ten.text = "10th: " + sNINE;
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sEIGHT && (PlayerManager.Get().stats.Timer + FT) > sSEVEN)
        {
            S_Eight.text = "8th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sSEVEN && (PlayerManager.Get().stats.Timer + FT) > sSIX)
        {
            S_Seven.text = "7th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sSIX && (PlayerManager.Get().stats.Timer + FT) > sFIVE)
        {
            S_Six.text = "6th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
            if ((PlayerManager.Get().stats.Timer + FT) <= sFIVE && (PlayerManager.Get().stats.Timer + FT) > sFOUR)
        {
            S_Five.text = "5th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Six.text = "6th: " + sFIVE;
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sFOUR && (PlayerManager.Get().stats.Timer + FT) > sTHREE)
        {
            S_Four.text = "4th: " + (PlayerManager.Get().stats.Timer + FT);
            S_Five.text = "5th: " + sFOUR;
            S_Six.text = "6th: " + sFIVE;
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        if ((PlayerManager.Get().stats.Timer + FT) <= sTHREE && (PlayerManager.Get().stats.Timer + FT) > sTWO)
        {
            S_Three.text = "3rd:" + (PlayerManager.Get().stats.Timer + FT);
            S_Four.text = "4th: " + sTHREE;
            S_Five.text = "5th: " + sFOUR;
            S_Six.text = "6th: " + sFIVE;
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        else if ((PlayerManager.Get().stats.Timer + FT) <= sTWO && (PlayerManager.Get().stats.Timer + FT) > sONE)
        {
            S_Two.text = "2nd:" + (PlayerManager.Get().stats.Timer + FT);
            S_Three.text = "3rd:" + sTWO;
            S_Four.text = "4th: " + sTHREE;
            S_Five.text = "5th: " + sFOUR;
            S_Six.text = "6th: " + sFIVE;
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }
        else if ((PlayerManager.Get().stats.Timer + FT) <= sONE)
        {
            S_One.text = "1st:" + (PlayerManager.Get().stats.Timer + FT);
            S_Two.text = "2nd:" + sONE;
            S_Three.text = "3rd:" + sTWO;
            S_Four.text = "4th: " + sTHREE;
            S_Five.text = "5th: " + sFOUR;
            S_Six.text = "6th: " + sFIVE;
            S_Seven.text = "7th: " + sSIX;
            S_Eight.text = "8th: " + sSEVEN;
            S_Nine.text = "9th: " + sEIGHT;
            S_Ten.text = "10th: " + sNINE;
        }

        else
        {
            return;
        }
    }
}
