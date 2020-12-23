using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ScoreBoard2 : MonoBehaviour
{
    public static int Score = ScoreBoard.Score;


    private void OnGUI()
    {
        GUI.Box(new Rect(150, 50, 200, 100), "Score: " + Score.ToString());


    }


}
