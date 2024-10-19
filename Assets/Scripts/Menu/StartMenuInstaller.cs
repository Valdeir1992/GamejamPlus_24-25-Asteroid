using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartMenuInstaller : MonoInstaller
{
    [SerializeField] private CreditScreenController _creditScreeControllerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<CreditScreenController>().FromInstance(_creditScreeControllerPrefab).AsSingle();
        Container.Bind<Button>().WithId("Play").FromMethod(FindBtnPlay).AsTransient();
        Container.Bind<Button>().WithId("Credits").FromMethod(FindBtnCredits).AsTransient();
    }
    private Button FindBtnPlay()
    {
        return FindButton("BTN_Play");
    }
    private Button FindBtnCredits()
    {
        return FindButton("BTN_Credits");
    }
    private Button FindButton(string Name)
    {
        return GameObject.FindObjectsByType<Button>(FindObjectsSortMode.None).First(x => x.name == Name);
    }
}
