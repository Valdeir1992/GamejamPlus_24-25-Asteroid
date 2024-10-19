using UnityEngine;
using Zenject;

public class UpgradeInstaller : MonoInstaller
{
    [SerializeField] private Sprite _cardBackground; 
    [SerializeField] private UpgradeHUDController _cardUIControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<Sprite>().WithId("Card Background").FromInstance(_cardBackground).AsCached();
        Container.Bind<CardUIController>().FromComponentInHierarchy().AsCached();
        Container.Bind<UpgradeHUDController>().FromInstance(_cardUIControllerPrefab).AsCached();
    }
}
