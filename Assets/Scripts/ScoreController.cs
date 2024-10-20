using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _currenScore;
    public Action<int> OnUpdateScore;

    public int CurrenScore { get => _currenScore;}
    public int BestScore { get
        {
            if (PlayerPrefs.HasKey("BestScore"))
            {
                return PlayerPrefs.GetInt("BestScore");
            }
            return 0;
        } }

    public void UpdateScore(int score)
    {
        _currenScore += score;
        OnUpdateScore?.Invoke(_currenScore);
    }

    public void SaveRecord()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            var score = PlayerPrefs.GetInt("BestScore");
            if(score < _currenScore)
            {
                PlayerPrefs.SetInt("BestScore", _currenScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt("BestScore", _currenScore);
        }
    }
}
