﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public static int Score = 0;
    

    private void OnGUI()
    {
        GUI.Box(new Rect(150,50,200,100), "Score: " + Score.ToString());
      

    }
}
