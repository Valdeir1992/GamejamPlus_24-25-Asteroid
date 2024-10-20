using UnityEngine;
using Zenject;

public class XPInstaller : MonoInstaller
{ 
    public override void InstallBindings()
    {
        Container.Bind<XPController>().FromComponentInHierarchy().AsCached();
    }
}
