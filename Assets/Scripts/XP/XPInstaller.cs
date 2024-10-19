using UnityEngine;
using Zenject;

public class XPInstaller : MonoInstaller
{
    [SerializeField] private XPController _xpControllerPrefab;
    public override void InstallBindings()
    {
        Container.Bind<XPController>().FromComponentInNewPrefab(_xpControllerPrefab).AsCached();
    }
}
