using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalScore : MonoBehaviour
{
    public static int finalScore = 0;


    private void OnGUI()
    {
        GUI.Box(new Rect(150, 50, 100, 100), "Total Score: " + finalScore.ToString());


    }

}
