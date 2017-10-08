using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    public string NextLevel;

    void OnTriggerEnter(Collider Other)
    {
        //pick up the END item and win the game
        if (Other.gameObject.CompareTag("Player"))
        {
            //setting the timer to freeze, to be displayed at the end
            //PlayerManager.Get().stats.TimeFreeze = true;
            //load the Win scene due to finish condition being met
            SceneManager.LoadScene(NextLevel);
        }
    }
}
