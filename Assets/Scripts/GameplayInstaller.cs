using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameOverScreenController _gameplayScreenPrefab;
    public override void InstallBindings()
    {
        Container.Bind<GameplayController>().FromComponentInHierarchy().AsCached();
        Container.Bind<GameplayHudController>().FromComponentInHierarchy().AsCached();
        Container.Bind<GameOverScreenController>().FromInstance(_gameplayScreenPrefab).AsSingle();
    }
}
