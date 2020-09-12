using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool gameStarted;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
       
    }


    //this is  called when user taps to play Ah yes, comment explainations
    public void TapToPlay()
    {
        gameStarted = true;
    }

    public void gameEnd()
    {
        
    }

    

}
