using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text S_Three;
    public Text S_Two;
    public Text S_One;

    private int sONE;
    private int sTWO;
    private int sTHREE;

    void Start()
    {
        sONE = 20;
        sTWO = 30;
        sTHREE = 40;

        S_One = sONE;
        S_Two = sTWO;
        S_Three = sTHREE;
        
    }
    void Update()
    {
        
        //this shows the final time achieved at the end of the level
        //S_Three = "Your final time was: " + PlayerManager.Get().stats.Timer;
        if (sTWO > PlayerManager.Get().stats.Timer > sTHREE)
        {

        }
    }

}
