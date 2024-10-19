using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartMenuController : MonoBehaviour
{
    [Inject(Id ="Play")] private Button _btnPlay;
    [Inject(Id = "Credits")] private Button _btnCredits;
    [Inject] private CreditScreenController _creditsScreenControllerPrefab; 

    private void Awake()
    {
        _btnCredits.onClick.AddListener(Credits);
        _btnPlay.onClick.AddListener(Play);
    }


    private void Play()
    {
        _btnCredits.interactable = false;
        _btnPlay.interactable = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    public void Credits()
    {
        _btnCredits.interactable = false;
        _btnPlay.interactable = false;
        var instance = Instantiate(_creditsScreenControllerPrefab);
        instance.OnClose += ActiveButtons;
    }

    private void ActiveButtons()
    {
        _btnCredits.interactable = true;
        _btnPlay.interactable = true;
    }
}
