using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _currenScore;
    public Action<int> OnUpdateScore;


    private void OnEnable()
    {
        AsteroidBehaviour.OnDestroy += UpdateScore;
    }
    private void OnDisable()
    {
        AsteroidBehaviour.OnDestroy -= UpdateScore;
    }



    public void UpdateScore(int score)
    {
        _currenScore += score;
        OnUpdateScore?.Invoke(_currenScore);
    }
}
