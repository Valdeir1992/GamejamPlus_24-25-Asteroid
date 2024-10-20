using UnityEngine;
using Zenject;

public class UpgradeHUDController : MonoBehaviour
{ 
    [SerializeField] private CardUIController _cardUIPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private AudioSource _source;

    private void Start()
    {
        _source.Play();
        FindAnyObjectByType<GameplayController>().PauseAudio();
    }
    private void OnDisable()
    {
        FindAnyObjectByType<GameplayController>().ResumeAudio(); 
        _source.Pause();
    }
    public void ShowCards(UpgradeSO[] upgradeSOs)
    {
        foreach(var upgrade in upgradeSOs)
        {
            var cardUI = Instantiate(_cardUIPrefab, _container);
            cardUI.SetupCard(upgrade);
            cardUI.OnClick += () =>
            {
                FindAnyObjectByType<GameplayController>().Resume();
                Destroy(gameObject);
            };
        }
        FindAnyObjectByType<GameplayController>().Pause();
    }
}
