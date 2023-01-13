using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Variables GD
    [Header("Variables")]
    public int ScorePerSecond;
    private int _currentScore;

    // Text
    [Header("Text")]
    public TMP_Text ScoreText;

    // Timer
    private float time;
    private float targetTime = 1;



    private void Update()
    {
        // Display Current Score
        ScoreText.text = _currentScore.ToString();
        Timer();

    }

    private void Timer()
    {
        time += Time.deltaTime;

        if (time >= targetTime)
        {
            time = 0.0f;

            // Add Score Every Second
            _currentScore += ScorePerSecond;
        }
    }

    public void AddScore(int score)
    {
        _currentScore += score;
    }
}
