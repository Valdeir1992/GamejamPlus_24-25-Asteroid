using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameplayController : MonoBehaviour
{
    float CurrentTime;
    bool InGameplay;
    public float MaxGameplayTime;
    public Action<float> OnUpdateTime;
    [Inject] private GameplayHudController _gameplayHUDController;
    private void Start()
    {
        StartCoroutine(Corotine_Timer());
    }
    IEnumerator Corotine_Timer()
    {

        CurrentTime = 0;

        while (InGameplay || CurrentTime <= MaxGameplayTime)
        {

            CurrentTime += Time.deltaTime;
            if (OnUpdateTime != null)
            {
                OnUpdateTime(CurrentTime);
            }
            yield return null;
        }

        GameOver();

    }

    public void GameOver()
    {
        _gameplayHUDController.ShowGameOverScreen();
    }
}
