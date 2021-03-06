﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
using Proyecto26;
using UnityEngine.UI;

public class s : MonoBehaviour
{
    public Text scoreText;
    public InputField nameText;
    public int scoreSum;

    public static int playerScore;
    public static string playerName;

    // private System.Random random = new System.Random();

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        keywords.Add("nuts", () =>
        {
            GoCalled00();
        });

        keywords.Add("green", () =>
        {
            GoCalled01();
        });

        keywords.Add("jump", () =>
        {
            GoCalled02();
        });

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizerOnPhraseRecognizer;
        keywordRecognizer.Start();

       
        //playerScore = random.Next(0, 10);
        scoreText.text = "Score: " + playerScore;
    }

    void KeywordRecognizerOnPhraseRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }

    }



    void GoCalled00()
    {
        Debug.Log("Excellent. The answer is berries.");
        //this.transform.Translate(Vector3.up * 10.0f);
        //userScore = ScoreBoard.Score;
        ScoreBoard2.Score += 5;
        scoreSum = ScoreBoard.Score + ScoreBoard2.Score;
        playerScore = scoreSum;
        
        //playerScore = random.Next(0, 10);
        scoreText.text = "Score: " + playerScore;
        //userScore = ScoreBoard.Score;

        //txt022.textDisplay += "Excellent.The answer is berries";
    }

    void GoCalled01()
    {
        Debug.Log("Opps!You are wrong.The answer is berries.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard2.Score -= 5;
        scoreSum = ScoreBoard.Score + ScoreBoard2.Score;
        playerScore = scoreSum;
        //playerScore = random.Next(0, 10);
        scoreText.text = "Score: " + playerScore;
        //txt022.textDisplay += "Opps!You are wrong.The answer is berries.";
    }

    void GoCalled02()
    {
        Debug.Log("Opps!You are wrong.The answer is berries.");
        //this.transform.Translate(Vector3.up * 10.0f);
        ScoreBoard2.Score -= 5;
        scoreSum = ScoreBoard.Score + ScoreBoard2.Score;
        playerScore = scoreSum;
       
        //playerScore = random.Next(0, 10);
        scoreText.text = "Score: " + playerScore;

        // txt022.textDisplay += "Opps!You are wrong.The answer is berries.";
    }

    public void OnSubmit()
    {
        playerName = nameText.text;
        PostToDatabase();
    }

    public void PostToDatabase()
    {
        User user = new User();
        RestClient.Post("https://fyp-testing1.firebaseio.com/.json", user);
    }
}
