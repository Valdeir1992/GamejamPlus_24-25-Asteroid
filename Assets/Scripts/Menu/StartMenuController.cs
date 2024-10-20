using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartMenuController : MonoBehaviour
{

    private FadeController Fade;
    [SerializeField] private SelectSpaceShipScreenController _selectSpaceShipScreenControllerPrefab;
    [Inject(Id ="Play")] private Button _btnPlay;
    [Inject(Id = "Credits")] private Button _btnCredits;
    [Inject] private CreditScreenController _creditsScreenControllerPrefab; 

    private void Awake()
    {
        Fade = FindAnyObjectByType<FadeController>();
        _btnCredits.onClick.AddListener(Credits);
        _btnPlay.onClick.AddListener(Play);
    }

    private void Start()
    {
        Fade.FadeIn(1, null, 0);
    }
    private void Play()
    {
        var screen = Instantiate(_selectSpaceShipScreenControllerPrefab);
        screen.OnSelect +=()=> Fade.FadeOut(1,() => { UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay"); },0);
        _btnCredits.interactable = false;
        _btnPlay.interactable = false;
        
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
