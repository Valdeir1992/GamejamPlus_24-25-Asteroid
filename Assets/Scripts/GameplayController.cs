using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameplayController : MonoBehaviour
{
    float CurrentTime;
    bool InGameplay;
    public float MaxGameplayTime;
    private float _dificultyTime;
    private static int _dificulty = 1;
    public Action<float> OnUpdateTime;
    [SerializeField] private CharacterMediator[] _spaceShips;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _audioStart;
    [SerializeField] private AudioClip _audioLoop;
    [Inject] private GameplayHudController _gameplayHUDController;

    public static int Dificulty { get => _dificulty;}

    private void Start()
    {
        StartCoroutine(Corotine_Timer());
        PlayAudio();
        var spaceShipName = (PlayerPrefs.HasKey("SpaceShip"))? PlayerPrefs.GetString("SpaceShip"): "Bebop";
        Instantiate(_spaceShips.First(x => x.Name == spaceShipName), Vector3.zero, Quaternion.identity);
    }
    private void PlayAudio()
    {
        _source.clip = _audioStart;
        _source.Play();
        StartCoroutine(Coroutine_StartLoop());
    }
    public void PauseAudio()
    {
        _source.Pause();
    }
    public void ResumeAudio()
    {
        _source.Play();
    }
    private IEnumerator Coroutine_StartLoop()
    {
        yield return new WaitUntil(() => !_source.isPlaying);
        _source.clip = _audioLoop;
        _source.Play();
        _source.loop = true;
    }
    IEnumerator Corotine_Timer()
    {

        CurrentTime = 0;

        while (InGameplay || CurrentTime <= MaxGameplayTime)
        {

            CurrentTime += Time.deltaTime;
            _dificultyTime += Time.deltaTime;
            if(_dificultyTime > 60)
            {
                _dificulty++;
                _dificultyTime = 0;
            }
            if (OnUpdateTime != null)
            {
                OnUpdateTime(MaxGameplayTime - CurrentTime);
            }
            yield return null;
        }

        GameOver();

    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        _gameplayHUDController.ShowGameOverScreen();
        FindAnyObjectByType<ScoreController>().SaveRecord();
    }
}
