using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameplayHudController : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Timer;
    private GameplayController controller;
    private ScoreController _scoreController;
    [Inject] private GameOverScreenController _gameOverScreenPrefab;

    private void Awake()
    {
        controller = FindAnyObjectByType<GameplayController>();
        _scoreController = FindAnyObjectByType<ScoreController>();
        controller.OnUpdateTime += UpdateHudTimer;
        _scoreController.OnUpdateScore += UpdateHudScore;
    }
    void UpdateHudScore(int score)
    {
        Score.SetText($"Score: {score:D5}");
    }

    void UpdateHudTimer(float timeElepsed)
    {
        TimeSpan timer = TimeSpan.FromSeconds(timeElepsed);
        Timer.SetText($"Timer: {timer.Minutes:D2}:{timer.Seconds:D2}");
    }
    public void ShowGameOverScreen()
    {
        Instantiate(_gameOverScreenPrefab,transform);
    }

 
}
