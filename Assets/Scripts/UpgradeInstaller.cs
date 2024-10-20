using UnityEngine;
using Zenject;

public class UpgradeInstaller : MonoInstaller
{
    [SerializeField] private Sprite _cardBackground; 
    [SerializeField] private UpgradeHUDController _upgradeHUDControllerPrefab;
    [SerializeField] private CardUIController _cardUIControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<Sprite>().WithId("Card Background").FromInstance(_cardBackground).AsCached();
        Container.Bind<CardUIController>().FromInstance(_cardUIControllerPrefab).AsCached();
        Container.Bind<UpgradeHUDController>().FromInstance(_upgradeHUDControllerPrefab).AsCached();
    }
}
