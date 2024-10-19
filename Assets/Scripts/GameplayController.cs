using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    float CurrentTime;
    bool InGameplay;
    public float MaxGameplayTime;
    public Action<float> OnUpdateTime;

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

    private void GameOver()
    {
        
    }
}
