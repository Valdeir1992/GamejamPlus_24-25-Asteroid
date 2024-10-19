using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayHudController : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Timer;
    private GameplayController controller;

    private void Awake()
    {
        controller = FindAnyObjectByType<GameplayController>();
        controller.OnUpdateTime += UpdateHudTimer;
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


 
}
